using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Word = Microsoft.Office.Interop.Word;

namespace flooring_shop
{
    public partial class SellerOrderGo : Form
    {
        private List<Product> selectedProducts; // Список выбранных товаров

        // Конструктор, принимающий только список товаров
        public SellerOrderGo(List<Product> products, SellerOrder parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
            selectedProducts = products;

            // Инициализация DataGridView (добавление столбцов)
            InitializeDataGridView();

            LoadProducts(); // Загружаем товары в DataGridView
            UpdateTotalPrice(); // Обновляем общую стоимость
        }

        // Инициализация DataGridView (добавление столбцов)
        private void InitializeDataGridView()
        {
            // Очистка существующих столбцов
            CartDataGridView.Columns.Clear();

            // Добавление столбцов
            CartDataGridView.Columns.Add("ArticleColumn", "Артикул");
            CartDataGridView.Columns.Add("NameColumn", "Название");
            CartDataGridView.Columns.Add("PriceColumn", "Цена за шт.");
            CartDataGridView.Columns.Add("QuantityColumn", "Количество");
            CartDataGridView.Columns.Add("TotalColumn", "Сумма");

            // Настройка свойств DataGridView
            CartDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CartDataGridView.AllowUserToAddRows = false;
            CartDataGridView.AllowUserToDeleteRows = false;
            CartDataGridView.ReadOnly = false; // Разрешаем редактирование ячеек по умолчанию

            // Запрещаем редактирование всех столбцов, кроме "Количество"
            foreach (DataGridViewColumn column in CartDataGridView.Columns)
            {
                column.ReadOnly = true; // Все столбцы доступны только для чтения
            }
            CartDataGridView.Columns["QuantityColumn"].ReadOnly = false; // Разрешаем редактирование только столбца "Количество"

            // Обработка изменения значения в столбце "Количество"
            CartDataGridView.CellEndEdit += CartDataGridView_CellEndEdit;
        }

        // Загрузка товаров в DataGridView
        private void LoadProducts()
        {
            CartDataGridView.Rows.Clear();
            foreach (var product in selectedProducts)
            {
                CartDataGridView.Rows.Add(
                    product.Article,
                    product.Name,
                    product.Price.ToString("C"), // Форматируем как валюту
                    product.QuantityOrdered,
                    (product.Price * product.QuantityOrdered).ToString("C") // Сумма
                );
            }
        }

        // Обновление общей стоимости
        private void UpdateTotalPrice()
        {
            decimal totalPrice = selectedProducts.Sum(p => p.Price * p.QuantityOrdered);
            decimal discount = 0;

            // Скидка 7% при сумме заказа от 10000 руб
            if (totalPrice >= 10000)
            {
                discount = totalPrice * 0.07m;
                DiscountLabel.Text = $"Скидка 7%: -{discount:C}";
                DiscountLabel.Visible = true;
            }
            else
            {
                DiscountLabel.Visible = false;
            }

            TotalPriceLabel.Text = $"Итого: {(totalPrice - discount):C}";
        }

        // Обработка изменения количества товара
        private void CartDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3) // Проверяем, что редактировался столбец "Количество"
            {
                var row = CartDataGridView.Rows[e.RowIndex];
                string article = row.Cells["ArticleColumn"].Value.ToString();
                int newQuantity = Convert.ToInt32(row.Cells["QuantityColumn"].Value);

                // Находим товар в списке
                Product product = selectedProducts.FirstOrDefault(p => p.Article == article);
                if (product == null)
                {
                    MessageBox.Show("Товар не найден в списке.");
                    return;
                }

                // Проверка на отрицательное количество
                if (newQuantity < 0)
                {
                    MessageBox.Show("Количество не может быть отрицательным.");
                    row.Cells["QuantityColumn"].Value = product.QuantityOrdered; // Возвращаем старое значение
                    return;
                }

                // Проверка на превышение остатка на складе
                if (newQuantity > product.QuantityInStock)
                {
                    MessageBox.Show("Количество превышает остаток на складе.");
                    row.Cells["QuantityColumn"].Value = product.QuantityOrdered; // Возвращаем старое значение
                    return;
                }

                // Обновляем количество и сумму
                product.QuantityOrdered = newQuantity;
                row.Cells["TotalColumn"].Value = (product.Price * newQuantity).ToString("C"); // Обновляем сумму
                UpdateTotalPrice(); // Пересчитываем общую стоимость
            }
        }

        // Сохранение заказа в базе данных
        private void SaveOrderToDatabase()
        {
            try
            {
                DatabaseConnection dbConnection = new DatabaseConnection();

                if (dbConnection.OpenConnection())
                {
                    // Создаем запись в таблице Order
                    string orderQuery = @"
                        INSERT INTO `Order` (OrderDate, OrderDeliveryDate, UserID, OrderCode)
                        VALUES (@OrderDate, @OrderDeliveryDate, @UserID, @OrderCode)";

                    MySqlCommand orderCommand = new MySqlCommand(orderQuery, dbConnection.GetConnection());
                    orderCommand.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    orderCommand.Parameters.AddWithValue("@OrderDeliveryDate", DateTime.Now.AddDays(7)); // Пример: доставка через 7 дней
                    orderCommand.Parameters.AddWithValue("@UserID", 1); // Замените на ID текущего пользователя
                    orderCommand.Parameters.AddWithValue("@OrderCode", new Random().Next(1000, 9999)); // Генерация случайного кода заказа

                    orderCommand.ExecuteNonQuery();

                    // Получаем ID созданного заказа
                    long orderId = orderCommand.LastInsertedId;

                    // Создаем записи в таблице OrderProduct
                    foreach (var product in selectedProducts)
                    {
                        string orderProductQuery = @"
                            INSERT INTO OrderProduct (OrderID, ProductArticleNumber, ProdNumCount)
                            VALUES (@OrderID, @ProductArticleNumber, @ProdNumCount)";

                        MySqlCommand orderProductCommand = new MySqlCommand(orderProductQuery, dbConnection.GetConnection());
                        orderProductCommand.Parameters.AddWithValue("@OrderID", orderId);
                        orderProductCommand.Parameters.AddWithValue("@ProductArticleNumber", product.Article);
                        orderProductCommand.Parameters.AddWithValue("@ProdNumCount", product.QuantityOrdered);

                        orderProductCommand.ExecuteNonQuery();

                        // Обновляем остаток на складе
                        string updateStockQuery = $"UPDATE Product SET ProductQuantityInStock = ProductQuantityInStock - {product.QuantityOrdered} WHERE ProductArticleNumber = '{product.Article}'";
                        MySqlCommand updateStockCommand = new MySqlCommand(updateStockQuery, dbConnection.GetConnection());
                        updateStockCommand.ExecuteNonQuery();
                    }

                    dbConnection.CloseConnection();
                    MessageBox.Show("Заказ успешно оформлен!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при оформлении заказа: " + ex.Message);
            }
        }

        // Создание чека в Word
        private void CreateReceipt()
        {
            try
            {
                // Создаем экземпляр Word и новый документ
                Word.Application wordApp = new Word.Application();
                Word.Document wordDoc = wordApp.Documents.Add();
                wordApp.Visible = true;

                // 1. Заголовок магазина (центрированный, жирный, 16pt)
                Word.Paragraph title = wordDoc.Content.Paragraphs.Add();
                title.Range.Text = "Магазин напольных покрытий «ПолыРоскоши»";
                title.Range.Font.Bold = 1;
                title.Range.Font.Size = 16;
                title.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                title.Range.InsertParagraphAfter();

                // 2. Подзаголовок "Чек заказа" (центрированный, жирный, 14pt)
                Word.Paragraph subtitle = wordDoc.Content.Paragraphs.Add();
                subtitle.Range.Text = "КАССОВЫЙ ЧЕК";
                subtitle.Range.Font.Bold = 1;
                subtitle.Range.Font.Size = 14;
                subtitle.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                subtitle.Range.InsertParagraphAfter();

                // 3. Информация о заказе (дата/время)
                Word.Paragraph orderInfo = wordDoc.Content.Paragraphs.Add();
                orderInfo.Range.Text = $"Дата: {DateTime.Now:dd.MM.yyyy HH:mm:ss}\n" +
                                      $"Номер заказа: {new Random().Next(1000, 9999)}";
                orderInfo.Range.Font.Size = 12;
                orderInfo.Range.InsertParagraphAfter();

                // 4. Горизонтальная линия-разделитель
                Word.Paragraph divider = wordDoc.Content.Paragraphs.Add();
                divider.Range.Text = new string('-', 50);
                divider.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                divider.Range.InsertParagraphAfter();

                // 5. Таблица с товарами (4 колонки)
                Word.Table table = wordDoc.Tables.Add(
                    Range: wordDoc.Range(wordDoc.Content.End - 1),
                    NumRows: selectedProducts.Count + 1, // +1 для заголовков
                    NumColumns: 4);

                // Настройка стиля таблицы
                table.Borders.Enable = 1; // Включаем все границы
                table.Range.Font.Size = 12;
                table.AllowAutoFit = true;

                // Заголовки таблицы (жирный шрифт)
                table.Cell(1, 1).Range.Text = "ТОВАР";
                table.Cell(1, 2).Range.Text = "ЦЕНА";
                table.Cell(1, 3).Range.Text = "КОЛ-ВО";
                table.Cell(1, 4).Range.Text = "СУММА";

                for (int i = 1; i <= 4; i++)
                {
                    table.Cell(1, i).Range.Font.Bold = 1;
                    table.Cell(1, i).Range.ParagraphFormat.Alignment =
                        Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                // Заполнение таблицы данными
                for (int i = 0; i < selectedProducts.Count; i++)
                {
                    var product = selectedProducts[i];
                    table.Cell(i + 2, 1).Range.Text = product.Name;
                    table.Cell(i + 2, 2).Range.Text = product.Price.ToString("C");
                    table.Cell(i + 2, 3).Range.Text = product.QuantityOrdered.ToString();
                    table.Cell(i + 2, 4).Range.Text = (product.Price * product.QuantityOrdered).ToString("C");

                    // Выравнивание для числовых колонок
                    table.Cell(i + 2, 2).Range.ParagraphFormat.Alignment =
                        Word.WdParagraphAlignment.wdAlignParagraphRight;
                    table.Cell(i + 2, 3).Range.ParagraphFormat.Alignment =
                        Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    table.Cell(i + 2, 4).Range.ParagraphFormat.Alignment =
                        Word.WdParagraphAlignment.wdAlignParagraphRight;
                }

                // 6. Итоговая информация (после таблицы)
                decimal totalSum = selectedProducts.Sum(p => p.Price * p.QuantityOrdered);
                decimal discount = totalSum >= 10000 ? totalSum * 0.07m : 0;
                decimal toPay = totalSum - discount;

                Word.Paragraph totalInfo = wordDoc.Content.Paragraphs.Add();
                totalInfo.Range.Text = $"\nПодитог: {totalSum:C}";
                totalInfo.Range.Font.Size = 12;
                totalInfo.Range.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphRight;
                totalInfo.Range.InsertParagraphAfter();

                if (discount > 0)
                {
                    Word.Paragraph discountInfo = wordDoc.Content.Paragraphs.Add();
                    discountInfo.Range.Text = $"Скидка 7%: -{discount:C}";
                    discountInfo.Range.Font.Size = 12;
                    discountInfo.Range.Font.Color = Word.WdColor.wdColorRed;
                    discountInfo.Range.ParagraphFormat.Alignment =
                        Word.WdParagraphAlignment.wdAlignParagraphRight;
                    discountInfo.Range.InsertParagraphAfter();
                }

                Word.Paragraph totalToPay = wordDoc.Content.Paragraphs.Add();
                totalToPay.Range.Text = $"ИТОГО К ОПЛАТЕ: {toPay:C}";
                totalToPay.Range.Font.Bold = 1;
                totalToPay.Range.Font.Size = 14;
                totalToPay.Range.Font.Color = Word.WdColor.wdColorDarkBlue;
                totalToPay.Range.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphRight;
                totalToPay.Range.InsertParagraphAfter();

                // 7. Нижний колонтитул (благодарность)
                Word.Paragraph footer = wordDoc.Content.Paragraphs.Add();
                footer.Range.Text = "\nСпасибо за покупку!\n" +
                                   "Телефон для справок: +7 (123) 456-78-90";
                footer.Range.Font.Italic = 1;
                footer.Range.Font.Size = 11;
                footer.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                // 8. Автосохранение с уникальным именем
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = Path.Combine(desktopPath, $"Чек_{DateTime.Now:yyyyMMdd_HHmmss}.docx");

                wordDoc.SaveAs(fileName);
                MessageBox.Show($"Чек сохранен: {fileName}", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании чека:\n{ex.Message}", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка "Оформить заказ"
        private void ConfirmBtn_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Оформить заказ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Сохраняем заказ в базе данных
                SaveOrderToDatabase();

                // Спрашиваем, нужно ли распечатать чек
                DialogResult printResult = MessageBox.Show("Распечатать чек?", "Чек", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (printResult == DialogResult.Yes)
                {
                    CreateReceipt();
                }
                
                this.Close();
            }
        }

        // Кнопка "Вернуться к товарам"
        private void BackToProductsBtn_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Убрать товары с заказа?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                selectedProducts.Clear(); // Очищаем список товаров
                this.Close(); // Закрываем форму
            }
            else
            {
                this.Hide();
            }
        }
        private SellerOrder parentForm;
        private void SellerOrderGo_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentForm.LoadProducts();
        }
    }
}
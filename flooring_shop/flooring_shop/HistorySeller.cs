using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Word = Microsoft.Office.Interop.Word;

namespace flooring_shop
{
    public partial class HistorySeller : Form
    {
        private DatabaseConnection dbConnection;
        private List<Product> selectedProductsForReturn = new List<Product>(); // Список выбранных товаров для возврата

        public HistorySeller()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();

            InitializeDataGridView(); // Настраиваем DataGridView
            LoadOrderHistory(); // Загружаем историю заказов при запуске формы
        }

        // Настройка DataGridView
        private void InitializeDataGridView()
        {
            DGVHistoryOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVHistoryOrder.AllowUserToAddRows = false;
            DGVHistoryOrder.ReadOnly = true; // Запрещаем редактирование
        }

        // Загрузка истории заказов
        private void LoadOrderHistory()
        {
            try
            {
                if (dbConnection.OpenConnection())
                {
                    // Запрос для получения истории заказов
                    string query = @"
                SELECT
                    `Order`.OrderID AS 'Номер заказа',
                    OrderProduct.ProductArticleNumber AS 'Артикул',
                    Product.ProductName AS 'Товар',
                    Product.ProductCost AS 'Цена',
                    Product.ProductQuantityInStock AS 'Остаток',
                    OrderProduct.ProdNumCount AS 'Количество',
                    (Product.ProductCost * OrderProduct.ProdNumCount) AS 'Сумма'
                FROM OrderProduct
                JOIN `Order` ON OrderProduct.OrderID = `Order`.OrderID
                JOIN Product ON OrderProduct.ProductArticleNumber = Product.ProductArticleNumber";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, dbConnection.GetConnection());
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    DGVHistoryOrder.DataSource = dataTable;
                    DGVHistoryOrder.Rows[0].Selected = false;
                    dbConnection.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке истории заказов: " + ex.Message);
            }
        }

        // Метод для возврата товара
        public void ReturnProduct(int orderId, string productName, int returnedQuantity)
        {
            try
            {
                if (dbConnection.OpenConnection())
                {
                    // Увеличиваем количество товара на складе
                    string updateStockQuery = $"UPDATE Product SET ProductQuantityInStock = ProductQuantityInStock + {returnedQuantity} WHERE ProductName = '{productName}'";
                    MySqlCommand updateStockCommand = new MySqlCommand(updateStockQuery, dbConnection.GetConnection());
                    updateStockCommand.ExecuteNonQuery();

                    // Получаем текущее количество товара в заказе
                    string getCurrentQuantityQuery = $"SELECT ProdNumCount FROM OrderProduct WHERE OrderID = {orderId} AND ProductArticleNumber = (SELECT ProductArticleNumber FROM Product WHERE ProductName = '{productName}')";
                    MySqlCommand getCurrentQuantityCommand = new MySqlCommand(getCurrentQuantityQuery, dbConnection.GetConnection());
                    int currentQuantity = Convert.ToInt32(getCurrentQuantityCommand.ExecuteScalar());

                    // Вычисляем новое количество товара в заказе
                    int newQuantity = currentQuantity - returnedQuantity;

                    if (newQuantity > 0)
                    {
                        // Обновляем количество в заказе
                        string updateOrderQuery = $"UPDATE OrderProduct SET ProdNumCount = {newQuantity} WHERE OrderID = {orderId} AND ProductArticleNumber = (SELECT ProductArticleNumber FROM Product WHERE ProductName = '{productName}')";
                        MySqlCommand updateOrderCommand = new MySqlCommand(updateOrderQuery, dbConnection.GetConnection());
                        updateOrderCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        // Удаляем товар из заказа, если количество стало нулевым
                        string deleteOrderQuery = $"DELETE FROM OrderProduct WHERE OrderID = {orderId} AND ProductArticleNumber = (SELECT ProductArticleNumber FROM Product WHERE ProductName = '{productName}')";
                        MySqlCommand deleteOrderCommand = new MySqlCommand(deleteOrderQuery, dbConnection.GetConnection());
                        deleteOrderCommand.ExecuteNonQuery();
                    }

                    dbConnection.CloseConnection();
                    MessageBox.Show("Товар возвращен на склад!");

                    // Обновляем историю заказов
                    LoadOrderHistory(); // Обновляем интерфейс
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при возврате товара: " + ex.Message);
            }
        }

        // Метод для получения цены товара
        private decimal GetProductPrice(string productName)
        {
            decimal price = 0;
            try
            {
                if (dbConnection.OpenConnection())
                {
                    string query = $"SELECT ProductCost FROM Product WHERE ProductName = '{productName}'";
                    MySqlCommand command = new MySqlCommand(query, dbConnection.GetConnection());
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        price = Convert.ToDecimal(result);
                    }

                    dbConnection.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении цены товара: " + ex.Message);
            }
            return price;
        }

        // Метод для создания чека в формате Word
        private void CreateReceipt(int orderId, string productName, int quantity, decimal totalPrice)
        {
            try
            {
                // Создаем новый документ Word
                Word.Application wordApp = new Word.Application();
                Word.Document wordDoc = wordApp.Documents.Add();
                wordApp.Visible = true; // Делаем Word видимым

                // Добавляем текст в документ
                Word.Paragraph paragraph = wordDoc.Content.Paragraphs.Add();
                paragraph.Range.Text = $"Чек по заказу №{orderId}\n\n";
                paragraph.Range.Text += $"ИНН: {new Random().Next(100000, 999999)}\n"; // Генерация случайного ИНН
                paragraph.Range.Text += $"Товар: {productName}\n";
                paragraph.Range.Text += $"Количество: {quantity}\n";
                paragraph.Range.Text += $"Общая сумма: {totalPrice:C}\n"; // Форматируем как валюту
                paragraph.Range.InsertParagraphAfter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании чека: " + ex.Message);
            }
        }

        // Обработчик нажатия кнопки для перехода на форму SellerOrder
        private void button1_Click(object sender, EventArgs e)
        {
            SellerOrder sellerOrder = new SellerOrder();
            this.Hide();
            sellerOrder.Show();
        }

        // Обработчик закрытия формы
        private void HistorySeller_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Authorization authorizationForm = new Authorization();
            authorizationForm.Show();
        }

        // Обработчик загрузки формы
        private void HistorySeller_Load_1(object sender, EventArgs e)
        {
            LoadOrderHistory(); // Обновляем историю заказов при каждой загрузке формы
        }

        // Обработчик нажатия кнопки "Оформить возврат"
        private void CloseProdIsOr_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVHistoryOrder.SelectedRows.Count > 0)
                {
                    // Список для хранения выбранных товаров и их заказов
                    List<(int OrderId, Product Product)> selectedProductsForReturn = new List<(int, Product)>();

                    foreach (DataGridViewRow row in DGVHistoryOrder.SelectedRows)
                    {
                        if (row.Cells["Артикул"].Value != null &&
                            row.Cells["Товар"].Value != null &&
                            row.Cells["Цена"].Value != null &&
                            row.Cells["Остаток"].Value != null &&
                            row.Cells["Количество"].Value != null)
                        {
                            int orderId = Convert.ToInt32(row.Cells["Номер заказа"].Value); // Получаем orderId из выбранной строки
                            string article = row.Cells["Артикул"].Value.ToString();
                            string name = row.Cells["Товар"].Value.ToString();
                            decimal price = Convert.ToDecimal(row.Cells["Цена"].Value);
                            int quantityInStock = Convert.ToInt32(row.Cells["Остаток"].Value);
                            int quantityOrdered = Convert.ToInt32(row.Cells["Количество"].Value);

                            Product product = new Product
                            {
                                Article = article,
                                Name = name,
                                Price = price,
                                QuantityInStock = quantityInStock,
                                QuantityOrdered = quantityOrdered
                            };

                            // Добавляем товар и его заказ в список
                            selectedProductsForReturn.Add((orderId, product));
                        }
                    }

                    // Открываем форму BackProduct с выбранными товарами и их заказами
                    BackProduct backProductForm = new BackProduct(selectedProductsForReturn, this);
                    backProductForm.ShowDialog();

                    // Очищаем список после закрытия формы
                    selectedProductsForReturn.Clear();
                }
                else
                {
                    MessageBox.Show("Выберите товары для возврата.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CheckOrderBtn_Click_1(object sender, EventArgs e)
        {
            if (DGVHistoryOrder.SelectedRows.Count > 0)
            {
                // Получаем данные из выбранной строки
                DataGridViewRow selectedRow = DGVHistoryOrder.SelectedRows[0];
                int orderId = Convert.ToInt32(selectedRow.Cells["Номер заказа"].Value);
                string productName = selectedRow.Cells["Товар"].Value.ToString();
                int quantity = Convert.ToInt32(selectedRow.Cells["Количество"].Value);
                decimal price = GetProductPrice(productName);

                // Создаем чек
                CreateReceipt(orderId, productName, quantity, price * quantity);
            }
            else
            {
                MessageBox.Show("Выберите заказ для создания чека.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}   
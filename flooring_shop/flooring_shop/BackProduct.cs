using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace flooring_shop
{
    public partial class BackProduct : Form
    {
        private List<(int OrderId, Product Product)> selectedProducts;
        private HistorySeller parentForm;

        public BackProduct(List<(int OrderId, Product Product)> products, HistorySeller parentForm)
        {
            InitializeComponent();
            this.selectedProducts = products;
            this.parentForm = parentForm;

            InitializeDataGridView(); // Настраиваем DataGridView
            LoadProducts(); // Загружаем товары в DataGridView
        }

        // Настройка DataGridView
        private void InitializeDataGridView()
        {
            BackProdDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            BackProdDataGridView.AllowUserToAddRows = false;
            BackProdDataGridView.ReadOnly = false; // Разрешаем редактирование

            // Добавляем столбцы
            BackProdDataGridView.Columns.Add("Номер заказа", "Номер заказа");
            BackProdDataGridView.Columns.Add("Артикул", "Артикул");
            BackProdDataGridView.Columns.Add("Товар", "Товар");
            BackProdDataGridView.Columns.Add("Цена", "Цена");
            BackProdDataGridView.Columns.Add("Остаток", "Остаток");
            BackProdDataGridView.Columns.Add("Количество", "Количество");
            BackProdDataGridView.Columns.Add("Сумма", "Сумма");

            // Запрещаем редактирование всех столбцов, кроме "Количество"
            foreach (DataGridViewColumn column in BackProdDataGridView.Columns)
            {
                if (column.HeaderText != "Количество")
                {
                    column.ReadOnly = true;
                }
            }

            // Обработка изменения значения в столбце "Количество"
            BackProdDataGridView.CellEndEdit += BackProdDataGridView_CellEndEdit;
        }

        // Загрузка товаров в DataGridView
        private void LoadProducts()
        {
            BackProdDataGridView.Rows.Clear();
            foreach (var (orderId, product) in selectedProducts)
            {
                BackProdDataGridView.Rows.Add(
                    orderId, // Номер заказа
                    product.Article, // Артикул товара
                    product.Name, // Название товара
                    product.Price, // Цена
                    product.QuantityInStock, // Остаток на складе
                    product.QuantityOrdered, // Количество в заказе
                    product.Price * product.QuantityOrdered // Сумма
                );
            }
        }

        // Обработка изменения количества товара
        private void BackProdDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5) // Проверяем, что редактировался столбец "Количество"
            {
                var row = BackProdDataGridView.Rows[e.RowIndex];
                string article = row.Cells["Артикул"].Value?.ToString(); // Проверка на null
                if (article == null) return;

                if (!int.TryParse(row.Cells["Количество"].Value?.ToString(), out int newQuantity))
                {
                    MessageBox.Show("Введите корректное количество.");
                    return;
                }

                // Находим товар в списке
                var selectedProduct = selectedProducts.FirstOrDefault(p => p.Product.Article == article);
                if (selectedProduct.Product == null)
                {
                    MessageBox.Show("Товар не найден в списке.");
                    return;
                }

                // Проверка на отрицательное количество
                if (newQuantity < 0)
                {
                    MessageBox.Show("Количество не может быть отрицательным.");
                    row.Cells["Количество"].Value = selectedProduct.Product.QuantityOrdered; // Возвращаем старое значение
                    return;
                }

                // Проверка на превышение количества в заказе
                if (newQuantity > selectedProduct.Product.QuantityOrdered)
                {
                    MessageBox.Show("Количество не может превышать количество в заказе.");
                    row.Cells["Количество"].Value = selectedProduct.Product.QuantityOrdered; // Возвращаем старое значение
                    return;
                }

                // Обновляем количество и сумму
                selectedProduct.Product.QuantityOrdered = newQuantity;
                row.Cells["Сумма"].Value = (selectedProduct.Product.Price * newQuantity).ToString("C"); // Обновляем сумму
            }
        }

        // Обработчик нажатия кнопки "Вернуть товар"
        private void BackOrderproduct_Click(object sender, EventArgs e)
        {
            foreach (var (orderId, product) in selectedProducts)
            {
                // Возвращаем товар на склад и обновляем количество в заказе
                parentForm.ReturnProduct(orderId, product.Name, product.QuantityOrdered);
            }

            MessageBox.Show("Товары успешно возвращены на склад.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void BackToHistoryBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Убрать товары с возврата?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                selectedProducts.Clear(); // Очищаем список товаров
                this.Close(); // Закрываем форму
            }
        }
    }
}
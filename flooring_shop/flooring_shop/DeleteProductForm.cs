using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace flooring_shop
{
    public partial class DeleteProductForm : Form
    {
        private DatabaseConnection dbConnection;
        private DataTable originalDataTable;
        private CommoditySpecialist parentForm;

        public DeleteProductForm(CommoditySpecialist parent)
        {
            InitializeComponent();
            this.parentForm = parent;
            dbConnection = new DatabaseConnection();
            InitializeSortComboBox();
            InitializeDataGridView();
            LoadCategories();
            LoadProducts();
        }

        private void InitializeSortComboBox()
        {
            CmbSort.Items.AddRange(new string[]
            {
            "Без сортировки",
            "Цена по возрастанию",
            "Цена по убыванию",
            "Название по алфавиту (А-Я)",
            "Название по алфавиту (Я-А)"
            });
            CmbSort.SelectedIndex = 0;
        }

        private void InitializeDataGridView()
        {
            DGVCMMSpecProd.ReadOnly = true;
            DGVCMMSpecProd.AllowUserToDeleteRows = false;
            DGVCMMSpecProd.AllowUserToAddRows = false;
            DGVCMMSpecProd.AllowUserToResizeRows = false;
            DGVCMMSpecProd.AllowUserToResizeColumns = false;
            DGVCMMSpecProd.AutoGenerateColumns = true;
        }

        private void LoadCategories()
        {
            try
            {
                if (dbConnection.OpenConnection())
                {
                    string query = "SELECT DISTINCT ProdCategoryName FROM ProdCategory";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, dbConnection.GetConnection());
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    DataRow allCategoriesRow = dataTable.NewRow();
                    allCategoriesRow["ProdCategoryName"] = "Все категории";
                    dataTable.Rows.InsertAt(allCategoriesRow, 0);

                    CmbFilter.DataSource = dataTable;
                    CmbFilter.DisplayMember = "ProdCategoryName";
                    CmbFilter.SelectedIndex = 0;

                    dbConnection.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке категорий: " + ex.Message);
            }
        }

        public void LoadProducts()
        {
            try
            {
                if (dbConnection.OpenConnection())
                {
                    string query = @"
                    SELECT
                        ProductArticleNumber AS 'Артикул',
                        ProductName AS 'Название',
                        ProductCost AS 'Цена',
                        ProductQuantityInStock AS 'Остаток',
                        ProductDescription AS 'Описание',
                        prodcategory.ProdCategoryName AS 'Категория'
                    FROM Product 
                    INNER JOIN prodcategory ON ProductCategory = ProdCategoryID";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, dbConnection.GetConnection()))
                    {
                        originalDataTable = new DataTable();
                        adapter.Fill(originalDataTable);
                        DGVCMMSpecProd.DataSource = originalDataTable;
                    }
                    dbConnection.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void UpdateDataGridView()
        {
            if (originalDataTable == null) return;

            DataTable filteredDataTable = originalDataTable.Copy();

            string selectedCategory = CmbFilter.Text;
            if (selectedCategory != "Все категории")
            {
                filteredDataTable.DefaultView.RowFilter = $"[Категория] = '{selectedCategory}'";
            }
            else
            {
                filteredDataTable.DefaultView.RowFilter = "";
            }

            string searchText = TxtSearch.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                string searchFilter = $"[Название] LIKE '%{searchText}%' OR [Артикул] LIKE '%{searchText}%'";
                if (string.IsNullOrEmpty(filteredDataTable.DefaultView.RowFilter))
                {
                    filteredDataTable.DefaultView.RowFilter = searchFilter;
                }
                else
                {
                    filteredDataTable.DefaultView.RowFilter += $" AND ({searchFilter})";
                }
            }

            string sortBy = CmbSort.Text;
            switch (sortBy)
            {
                case "Цена по возрастанию":
                    filteredDataTable.DefaultView.Sort = "[Цена] ASC";
                    break;
                case "Цена по убыванию":
                    filteredDataTable.DefaultView.Sort = "[Цена] DESC";
                    break;
                case "Название по алфавиту (А-Я)":
                    filteredDataTable.DefaultView.Sort = "[Название] ASC";
                    break;
                case "Название по алфавиту (Я-А)":
                    filteredDataTable.DefaultView.Sort = "[Название] DESC";
                    break;
                default:
                    filteredDataTable.DefaultView.Sort = "";
                    break;
            }

            DGVCMMSpecProd.DataSource = filteredDataTable.DefaultView.ToTable();
        }

        private void DeleteProduct(string articleNumber)
        {
            try
            {
                if (dbConnection.OpenConnection())
                {
                    string query = $"DELETE FROM Product WHERE ProductArticleNumber = '{articleNumber}'";
                    MySqlCommand command = new MySqlCommand(query, dbConnection.GetConnection());
                    command.ExecuteNonQuery();

                    dbConnection.CloseConnection();

                    MessageBox.Show("Товар успешно удален.");
                    LoadProducts(); // Обновляем данные после удаления
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении товара: " + ex.Message);
            }
        }

        private void CmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void CmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void DeleteProductForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentForm.LoadProducts();
            this.Close();
        }

        private void DGVCMMSpecProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (DGVCMMSpecProd.SelectedRows.Count > 0)
            {
                string articleNumber = DGVCMMSpecProd.SelectedRows[0].Cells["Артикул"].Value.ToString();
                string productName = DGVCMMSpecProd.SelectedRows[0].Cells["Название"].Value.ToString();

                DialogResult firstConfirm = MessageBox.Show($"Вы уверены, что хотите удалить товар '{productName}'?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (firstConfirm == DialogResult.Yes)
                {
                    DialogResult secondConfirm = MessageBox.Show("Точно удалить этот товар?", "Окончательное подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (secondConfirm == DialogResult.Yes)
                    {
                        DeleteProduct(articleNumber);
                        parentForm.LoadProducts(); // Обновляем данные на родительской форме
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

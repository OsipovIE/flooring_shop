using MySql.Data.MySqlClient;
using System;
using System.Text;
using System.Windows.Forms;

namespace flooring_shop
{
    public partial class AddProductForm : Form
    {
        private DatabaseConnection dbConnection;

        public AddProductForm()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            LoadUnits();
            GenerateArticleNumber();
        }

        private void LoadUnits()
        {
            cmbUnit.Items.AddRange(new string[] { "шт", "уп", "рул" });
            cmbUnit.SelectedIndex = 0;
        }

        private void GenerateArticleNumber()
        {
            Random random = new Random();
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";

            StringBuilder article = new StringBuilder();
            article.Append(letters[random.Next(letters.Length)]);
            article.Append(letters[random.Next(letters.Length)]);
            article.Append('-');
            for (int i = 0; i < 4; i++)
            {
                article.Append(numbers[random.Next(numbers.Length)]);
            }

            // Проверяем уникальность артикула
            while (IsArticleNumberExists(article.ToString()))
            {
                article.Clear();
                article.Append(letters[random.Next(letters.Length)]);
                article.Append(letters[random.Next(letters.Length)]);
                article.Append('-');
                for (int i = 0; i < 4; i++)
                {
                    article.Append(numbers[random.Next(numbers.Length)]);
                }
            }

            txtArticleNumber.Text = article.ToString();
        }

        private bool IsArticleNumberValid(string articleNumber)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(articleNumber, @"^[A-Z]{2}-\d{4}$");
        }

        private bool IsArticleNumberExists(string articleNumber)
        {
            try
            {
                if (dbConnection.OpenConnection())
                {
                    string query = $"SELECT COUNT(*) FROM Product WHERE ProductArticleNumber = '{articleNumber}'";
                    MySqlCommand command = new MySqlCommand(query, dbConnection.GetConnection());
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    dbConnection.CloseConnection();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при проверке артикула: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void txtArticleNumber_TextChanged(object sender, EventArgs e)
        {
            string article = txtArticleNumber.Text;

            if (string.IsNullOrEmpty(article))
            {
                errorProvider1.Clear();
                return;
            }

            // Проверка формата артикула
            if (!System.Text.RegularExpressions.Regex.IsMatch(article, @"^[A-Z]{2}-\d{4}$"))
            {
                errorProvider1.SetError(txtArticleNumber, "Формат: XX-9999 (X - заглавная буква, 9 - цифра)");
                return;
            }

            // Проверка уникальности артикула
            if (IsArticleNumberExists(article))
            {
                errorProvider1.SetError(txtArticleNumber, "Артикул уже существует");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void AddProductForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void btnGenerate_Click_1(object sender, EventArgs e)
        {
            GenerateArticleNumber();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            // Проверка валидности артикула
            if (!IsArticleNumberValid(txtArticleNumber.Text))
            {
                MessageBox.Show("Артикул должен состоять из двух заглавных букв, тире и четырех цифр (например, BL-3245).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка уникальности артикула
            if (IsArticleNumberExists(txtArticleNumber.Text))
            {
                MessageBox.Show("Товар с таким артикулом уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка остальных полей
            if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                !decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0 ||
                !int.TryParse(txtQuantity.Text, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Проверьте правильность введенных данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (dbConnection.OpenConnection())
                {
                    string query = @"
                        INSERT INTO Product 
                        (ProductArticleNumber, ProductName, ProductUnit, ProductCost, ProductQuantityInStock, ProductDescription, ProductCategory, ProductManufacturer)
                        VALUES (@Article, @Name, @Unit, @Price, @Quantity, @Description, 1, 1)";

                    MySqlCommand command = new MySqlCommand(query, dbConnection.GetConnection());
                    command.Parameters.AddWithValue("@Article", txtArticleNumber.Text);
                    command.Parameters.AddWithValue("@Name", txtProductName.Text);
                    command.Parameters.AddWithValue("@Unit", cmbUnit.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Description", txtDescription.Text);

                    command.ExecuteNonQuery();
                    dbConnection.CloseConnection();

                    MessageBox.Show("Товар успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении товара: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
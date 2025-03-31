using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace flooring_shop
{
    public partial class EditProductForm : Form
    {
        private DatabaseConnection dbConnection;
        private string articleNumber;

        public EditProductForm(string article, string name, decimal price, int quantity, string description)
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            articleNumber = article;

            ArticleTxt.Text = article;
            ArticleTxt.Text = name;
            PriceTxt.Text = price.ToString();
            QuantityTxt.Text = quantity.ToString();
            DescriptionTxt.Text = description;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(PriceTxt.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Введите корректную цену.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(QuantityTxt.Text, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Введите корректное количество.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Применить изменения?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (dbConnection.OpenConnection())
                    {
                        string query = @"
                            UPDATE Product 
                            SET ProductCost = @Price,
                                ProductQuantityInStock = @Quantity,
                                ProductDescription = @Description
                            WHERE ProductArticleNumber = @Article";

                        MySqlCommand command = new MySqlCommand(query, dbConnection.GetConnection());
                        command.Parameters.AddWithValue("@Price", price);
                        command.Parameters.AddWithValue("@Quantity", quantity);
                        command.Parameters.AddWithValue("@Description", DescriptionTxt.Text);
                        command.Parameters.AddWithValue("@Article", articleNumber);

                        command.ExecuteNonQuery();
                        dbConnection.CloseConnection();

                        MessageBox.Show("Изменения сохранены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении изменений: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditProductForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }
    }
}
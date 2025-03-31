using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace flooring_shop
{
    public partial class Authorization : Form
    {
        private bool passwordVisible = false;
        public Authorization()
        {
            InitializeComponent();
            Pwdtxt.PasswordChar = '•';
            EyeBtn.Text = "👁";
        }

        private void LoginIn_Click(object sender, EventArgs e)
        {
            string login = Logintxt.Text;
            string password = Pwdtxt.Text;
            string localAdminLogin = ConfigurationManager.AppSettings["LocalAdminLogin"];
            string localAdminPassword = ConfigurationManager.AppSettings["LocalAdminPassword"];
            if(login == localAdminLogin && password == localAdminPassword) 
            {
                DbSettingsForm setFo = new DbSettingsForm();
                this.Hide();
                setFo.ShowDialog();
                this.Show();
                return;
            }

            DatabaseConnection dbConnection = new DatabaseConnection();

            if (dbConnection.OpenConnection())
            {
                string query = $"SELECT UserRole, UserSurname, UserName, UserPatronymic FROM User WHERE UserLogin='{login}' AND UserPassword='{password}'";
                MySqlDataReader reader = dbConnection.ExecuteQuery(query);

                if (reader.HasRows)
                {
                    reader.Read();
                    int role = reader.GetInt32("UserRole");
                    string surname = reader["UserSurname"].ToString();
                    string name = reader["UserName"].ToString();
                    string patronymic = reader["UserPatronymic"].ToString();

                    // Форматируем ФИО: фамилия полностью, имя и отчество — инициалы
                    string userFullName = $"{surname} {name[0]}.{patronymic[0]}.";

                    switch (role)
                    {
                        case 1:
                            Administrator adminForm = new Administrator();
                            adminForm.SetAdminInfo(userFullName);
                            this.Hide();
                            adminForm.Show();
                            break;
                        case 2:
                            SellerForm sellerForm = new SellerForm();
                            sellerForm.SetUserInfo(userFullName); // Передаем информацию о пользователе
                            this.Hide();
                            sellerForm.Show();
                            break;
                        case 3:
                            CommoditySpecialist commodityForm = new CommoditySpecialist();
                            commodityForm.SetUserInfomerch(userFullName);
                            this.Hide();
                            commodityForm.Show();
                            break;
                        default:
                            MessageBox.Show("Доступ запрещен.");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль.");
                }

                reader.Close();
                dbConnection.CloseConnection();
            }
            else
            {
                MessageBox.Show("Ошибка подключения к базе данных.");
            }
        }

        private void Logintxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Pwdtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Authorization_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void EyeBtn_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;
            Pwdtxt.PasswordChar = passwordVisible ? '\0' : '•';
            EyeBtn.Text = passwordVisible ? "👁" : "👁";
        }
        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
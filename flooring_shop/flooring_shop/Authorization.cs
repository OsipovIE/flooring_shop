using System;
using System.Configuration;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace flooring_shop
{
    public partial class Authorization : Form
    {
        private bool passwordVisible = false;
        private string currentCaptcha= "";
        private int failedAttempts = 0;
        public Authorization()
        {
            InitializeComponent();
            Pwdtxt.PasswordChar = '•';
            EyeBtn.Text = "👁";
            // Изначально скрываем CAPTCHA
            CaptchaPanel.Visible = false;
            captchaTextBox.Enabled = false;
            checkCaptchaButton.Enabled = false;
            refreshCapthaButton.Enabled = false;
        }

        private void LoginIn_Click(object sender, EventArgs e)
        {
                if (CaptchaPanel.Visible)
                {
                    MessageBox.Show("Пожалуйста, сначала пройдите CAPTCHA");
                    return;
                }

                string login = Logintxt.Text;
                string password = Pwdtxt.Text;
                string localAdminLogin = ConfigurationManager.AppSettings["LocalAdminLogin"];
                string localAdminPassword = ConfigurationManager.AppSettings["LocalAdminPassword"];

                if (login == localAdminLogin && password == localAdminPassword)
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
                                sellerForm.SetUserInfo(userFullName);
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
                        failedAttempts = 0; // Сбрасываем счетчик при успешной авторизации
                    }
                    else
                    {
                        failedAttempts++;
                        MessageBox.Show("Неверный логин или пароль.");

                        // После 3 неудачных попыток показываем CAPTCHA
                        if (failedAttempts >= 3)
                        {
                            ShowCaptcha();
                        Logintxt.Text = "";
                        Pwdtxt.Text = "";
                        }
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
        private void GenerateCaptcha()
        {
            Random random = new Random();
            string letters = "ABCDEFGHJKLMNPQRSTUVWXYZ";
            string numbers = "23456789";

            // Генерируем 2 буквы
            char letter1 = letters[random.Next(letters.Length)];
            char letter2 = letters[random.Next(letters.Length)];

            // Генерируем 4 цифры
            char num1 = numbers[random.Next(numbers.Length)];
            char num2 = numbers[random.Next(numbers.Length)];
            char num3 = numbers[random.Next(numbers.Length)];
            char num4 = numbers[random.Next(numbers.Length)];

            // Собираем CAPTCHA (2 буквы + 4 цифры)
            currentCaptcha = $"{letter1}{letter2}{num1}{num2}{num3}{num4}";

            // Отображаем CAPTCHA
            СaptchaLabel.Text = currentCaptcha;

            // Добавляем визуальные эффекты
            СaptchaLabel.Font = new Font("Arial", 14, FontStyle.Bold);
            СaptchaLabel.ForeColor = Color.FromArgb(random.Next(100, 200), random.Next(100, 200), random.Next(100, 200));
        }
        private void ShowCaptcha()
        {
            GenerateCaptcha();
            CaptchaPanel.Visible = true;
            captchaTextBox.Enabled = true;
            checkCaptchaButton.Enabled = true;
            refreshCapthaButton.Enabled = true;

            // Блокируем основные поля ввода
            Logintxt.Enabled = false;
            Pwdtxt.Enabled = false;
            LoginIn.Enabled = false;
            EyeBtn.Enabled = false;
        }
        private void HideCaptcha()
        {
            CaptchaPanel.Visible = false;
            captchaTextBox.Text = "";
            captchaTextBox.Enabled = false;
            checkCaptchaButton.Enabled = false;
            refreshCapthaButton.Enabled = false;

            // Разблокируем основные поля ввода
            Logintxt.Enabled = true;
            Pwdtxt.Enabled = true;
            LoginIn.Enabled = true;
            EyeBtn.Enabled = true;
        }
        private void checkCaptchaButton_Click(object sender, EventArgs e)
        {
            if (captchaTextBox.Text == currentCaptcha)
            {
                MessageBox.Show("CAPTCHA пройдена успешно!");
                HideCaptcha();
                failedAttempts = 0; // Сбрасываем счетчик неудачных попыток
            }
            else
            {
                MessageBox.Show("Неверная CAPTCHA! Попробуйте еще раз.");
                GenerateCaptcha();
                captchaTextBox.Text = "";
                captchaTextBox.Focus();
            }
        }

        private void refreshCapthaButton_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
            captchaTextBox.Text = "";
            captchaTextBox.Focus();
        }

    }
}
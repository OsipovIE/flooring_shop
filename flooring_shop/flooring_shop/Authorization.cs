using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        private readonly Random random = new Random();
        private readonly string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
        public Authorization()
        {
            InitializeComponent();
            Pwdtxt.PasswordChar = '•';
            EyeBtn.Text = "#";
            HideCaptcha();
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
                        MessageBox.Show("Заполните поля еще раз, и пройдите капчу!","Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ShowCaptcha();
                        Logintxt.Text = "";
                        Pwdtxt.Text = "";
                        Logintxt.Focus();
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
            EyeBtn.Text = passwordVisible ? "👁" : "#";
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
            // Генерация 2 букв и 4 цифр
            currentCaptcha = GenerateRandomText(2, true) + GenerateRandomText(4, false);

            // Создаем изображение CAPTCHA
            Bitmap bmp = new Bitmap(CaptchaPanel.Width, CaptchaPanel.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                // Добавляем рельефность
                for (int i = 0; i < currentCaptcha.Length; i++)
                {
                    DrawCharacter(g, currentCaptcha[i], i);
                }

                // Добавляем зачёркивающую линию
                DrawStrikeThrough(g);

                // Добавляем шум
                AddNoise(g, 30);
            }

            CaptchaPanel.BackgroundImage = bmp;
        }
        private void ShowCaptcha()
        {
            GenerateCaptcha();
            CaptchaPanel.Visible = true;
            captchaTextBox.Enabled = true;
            checkCaptchaButton.Enabled = true;
            refreshCapthaButton.Enabled = true;
        }
        private void HideCaptcha()
        {
            CaptchaPanel.Visible = false;
            captchaTextBox.Text = "";
            captchaTextBox.Enabled = false;
            checkCaptchaButton.Enabled = false;
            refreshCapthaButton.Enabled = false;

        }
        private void checkCaptchaButton_Click(object sender, EventArgs e)
        {
            if (captchaTextBox.Text.Equals(currentCaptcha, StringComparison.OrdinalIgnoreCase))
            {

                HideCaptcha();
                MessageBox.Show("CAPTCHA пройдена успешно!");
                LoginIn_Click(sender,e);
                failedAttempts = 0; // Сбрасываем счетчик неудачных попыток
            }
            else
            {
                MessageBox.Show("Неверная CAPTCHA! Попробуйте еще раз.");
                GenerateCaptcha();
                captchaTextBox.Clear();
                Logintxt.Focus();
            }
        }

        private void refreshCapthaButton_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
            captchaTextBox.Clear();
            captchaTextBox.Focus();
        }
        private Color GetRandomColor()
        {
            return Color.FromArgb(random.Next(100, 200), random.Next(100, 200), random.Next(100, 200));
        }
        private void AddNoise(Graphics g, int noiseCount)
        {
            for (int i = 0; i < noiseCount; i++)
            {
                using (Pen pen = new Pen(GetRandomColor(), 0.5f))
                {
                    Point p1 = new Point(random.Next(CaptchaPanel.Width), random.Next(CaptchaPanel.Height));
                    Point p2 = new Point(p1.X + random.Next(-3, 3), p1.Y + random.Next(-3, 3));
                    g.DrawLine(pen, p1, p2);
                }
            }
        }
        private void DrawCharacter(Graphics g, char c, int position)
        {
            FontStyle style = (FontStyle)(random.Next(3) * 2); // Regular, Bold или Italic
            Font font = new Font("Arial", 14 + random.Next(6), style);

            // Эффект рельефа
            for (int i = 0; i < 3; i++)
            {
                Color color = i == 1 ? GetRandomColor() :
                             (i == 0 ? Color.LightGray : Color.DarkGray);

                PointF point = new PointF(
                    10 + position * 20 + (i == 0 ? -1 : (i == 2 ? 1 : 0)),
                    10 + (i == 0 ? -1 : (i == 2 ? 1 : 0)));

                using (SolidBrush brush = new SolidBrush(color))
                {
                    g.DrawString(c.ToString(), font, brush, point);
                }
            }
        }
        private void DrawStrikeThrough(Graphics g)
        {
            using (Pen pen = new Pen(GetRandomColor(), 1.5f))
            {
                pen.DashStyle = DashStyle.Dash;
                g.DrawLine(pen, 5, CaptchaPanel.Height / 2 + random.Next(-5, 5),
                    CaptchaPanel.Width - 5, CaptchaPanel.Height / 2 + random.Next(-5, 5));
            }
        }
        private string GenerateRandomText(int length, bool letters)
        {
            string subset = letters ? chars.Substring(0, 23) : chars.Substring(23);
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = subset[random.Next(subset.Length)];
            }
            return new string(result);
        }
    }
}
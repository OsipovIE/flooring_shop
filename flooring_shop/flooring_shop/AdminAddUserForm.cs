using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace flooring_shop
{
    public partial class AdminAddUserForm : Form
    {
        private DatabaseConnection dbConnection;
        private bool passwordVisible = false;

        public AdminAddUserForm()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            LoadRoles();
            PasswordTxt.PasswordChar = '•';
            EyeBtn.Text = "👁";
        }

        private void LoadRoles()
        {
            try
            {
                if (dbConnection.OpenConnection())
                {
                    string query = "SELECT RoleID, RoleName FROM Role";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, dbConnection.GetConnection());
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    RoleComboBox.DataSource = dataTable;
                    RoleComboBox.DisplayMember = "RoleName";
                    RoleComboBox.ValueMember = "RoleID";

                    dbConnection.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке ролей: " + ex.Message);
            }
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

        private void AdminAddUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void EyeBtn_Click_1(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;
            PasswordTxt.PasswordChar = passwordVisible ? '\0' : '•';
            EyeBtn.Text = passwordVisible ? "👁" : "👁";
        }

        private void SaveBtn_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SurnameTxt.Text) ||
               string.IsNullOrWhiteSpace(NameTxt.Text) ||
               string.IsNullOrWhiteSpace(PatronymicTxt.Text) ||
               string.IsNullOrWhiteSpace(LoginTxt.Text) ||
               string.IsNullOrWhiteSpace(PasswordTxt.Text))
            {
                MessageBox.Show("Заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (dbConnection.OpenConnection())
                {
                    // Проверка уникальности логина
                    string checkQuery = $"SELECT COUNT(*) FROM User WHERE UserLogin = '{LoginTxt.Text}'";
                    MySqlCommand checkCommand = new MySqlCommand(checkQuery, dbConnection.GetConnection());
                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Хеширование пароля
                    string hashedPassword = ComputeSha256Hash(PasswordTxt.Text);

                    // Добавление пользователя
                    string insertQuery = @"
                        INSERT INTO User (UserSurname, UserName, UserPatronymic, UserLogin, UserPassword, UserRole)
                        VALUES (@Surname, @Name, @Patronymic, @Login, @Password, @Role)";

                    MySqlCommand insertCommand = new MySqlCommand(insertQuery, dbConnection.GetConnection());
                    insertCommand.Parameters.AddWithValue("@Surname", SurnameTxt.Text);
                    insertCommand.Parameters.AddWithValue("@Name", NameTxt.Text);
                    insertCommand.Parameters.AddWithValue("@Patronymic", PatronymicTxt.Text);
                    insertCommand.Parameters.AddWithValue("@Login", LoginTxt.Text);
                    insertCommand.Parameters.AddWithValue("@Password", hashedPassword);
                    insertCommand.Parameters.AddWithValue("@Role", RoleComboBox.SelectedValue);

                    insertCommand.ExecuteNonQuery();
                    dbConnection.CloseConnection();

                    MessageBox.Show("Пользователь успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении пользователя: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
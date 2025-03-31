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
    public partial class AdminEditUserForm : Form
    {
        private DatabaseConnection dbConnection;
        private int userId;
        private bool passwordVisible = false;

        public AdminEditUserForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            dbConnection = new DatabaseConnection();
            LoadRoles();
            LoadUserData();
            NewPasswordTxt.PasswordChar = '•';
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

        private void LoadUserData()
        {
            try
            {
                if (dbConnection.OpenConnection())
                {
                    string query = $"SELECT UserSurname, UserName, UserPatronymic, UserLogin, UserRole FROM User WHERE UserID = {userId}";
                    MySqlCommand command = new MySqlCommand(query, dbConnection.GetConnection());
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        SurnameTxt.Text = reader["UserSurname"].ToString();
                        NameTxt.Text = reader["UserName"].ToString();
                        PatronymicTxt.Text = reader["UserPatronymic"].ToString();
                        LoginTxt.Text = reader["UserLogin"].ToString();
                        RoleComboBox.SelectedValue = reader["UserRole"];
                    }

                    reader.Close();
                    dbConnection.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных пользователя: " + ex.Message);
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

        private void EyeBtn_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;
            NewPasswordTxt.PasswordChar = passwordVisible ? '\0' : '•';
            EyeBtn.Text = passwordVisible ? "👁" : "👁";
        }

        private void AdminEditUserForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SurnameTxt.Text) ||
                string.IsNullOrWhiteSpace(NameTxt.Text) ||
                string.IsNullOrWhiteSpace(PatronymicTxt.Text) ||
                string.IsNullOrWhiteSpace(LoginTxt.Text))
            {
                MessageBox.Show("Заполните все обязательные поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (dbConnection.OpenConnection())
                {
                    // Проверка уникальности логина (кроме текущего пользователя)
                    string checkQuery = $"SELECT COUNT(*) FROM User WHERE UserLogin = '{LoginTxt.Text}' AND UserID != {userId}";
                    MySqlCommand checkCommand = new MySqlCommand(checkQuery, dbConnection.GetConnection());
                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Обновление данных пользователя
                    string updateQuery = @"
                        UPDATE User 
                        SET UserSurname = @Surname,
                            UserName = @Name,
                            UserPatronymic = @Patronymic,
                            UserLogin = @Login,
                            UserRole = @Role
                        WHERE UserID = @UserID";

                    // Если введен новый пароль, добавляем его к запросу
                    if (!string.IsNullOrWhiteSpace(NewPasswordTxt.Text))
                    {
                        string hashedPassword = ComputeSha256Hash(NewPasswordTxt.Text);
                        updateQuery = updateQuery.Replace("UserRole = @Role", "UserRole = @Role, UserPassword = @Password");
                    }

                    MySqlCommand updateCommand = new MySqlCommand(updateQuery, dbConnection.GetConnection());
                    updateCommand.Parameters.AddWithValue("@Surname", SurnameTxt.Text);
                    updateCommand.Parameters.AddWithValue("@Name", NameTxt.Text);
                    updateCommand.Parameters.AddWithValue("@Patronymic", PatronymicTxt.Text);
                    updateCommand.Parameters.AddWithValue("@Login", LoginTxt.Text);
                    updateCommand.Parameters.AddWithValue("@Role", RoleComboBox.SelectedValue);
                    updateCommand.Parameters.AddWithValue("@UserID", userId);

                    if (!string.IsNullOrWhiteSpace(NewPasswordTxt.Text))
                    {
                        string hashedPassword = ComputeSha256Hash(NewPasswordTxt.Text);
                        updateCommand.Parameters.AddWithValue("@Password", hashedPassword);
                    }

                    updateCommand.ExecuteNonQuery();
                    dbConnection.CloseConnection();

                    MessageBox.Show("Данные пользователя успешно обновлены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении данных пользователя: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
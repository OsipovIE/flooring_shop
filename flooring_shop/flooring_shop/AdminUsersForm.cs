using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flooring_shop
{
    public partial class AdminUsersForm : Form
    {
        private DatabaseConnection dbConnection;

        public AdminUsersForm()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                if (dbConnection.OpenConnection())
                {
                    string query = @"
                        SELECT 
                            UserID, 
                            UserSurname AS 'Фамилия', 
                            UserName AS 'Имя', 
                            UserPatronymic AS 'Отчество', 
                            UserLogin AS 'Логин', 
                            RoleName AS 'Роль'
                        FROM User 
                        JOIN Role ON UserRole = RoleID";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, dbConnection.GetConnection());
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    DGVUsers.DataSource = dataTable;
                    DGVUsers.Columns["UserID"].Visible = false;

                    dbConnection.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке пользователей: " + ex.Message);
            }
        }

        private void AdminUsersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Authorization auth = new Authorization();
            auth.Show();
        }

        private void EditUserBtn_Click_1(object sender, EventArgs e)
        {
            if (DGVUsers.SelectedRows.Count == 1)
            {
                int userId = Convert.ToInt32(DGVUsers.SelectedRows[0].Cells["UserID"].Value);
                AdminEditUserForm editUserForm = new AdminEditUserForm(userId);
                if (editUserForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUsers(); // Обновляем список после редактирования
                }
            }
            else if (DGVUsers.SelectedRows.Count > 1)
            {
                MessageBox.Show("Можно редактировать только одного пользователя одновременно.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Выберите пользователя для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddUserBtn_Click_1(object sender, EventArgs e)
        {
            AdminAddUserForm addUserForm = new AdminAddUserForm();
            if (addUserForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers(); // Обновляем список после добавления
            }
        }

        private void DeleteUserBtn_Click_1(object sender, EventArgs e)
        {
            if (DGVUsers.SelectedRows.Count > 0)
            {
                string message = "Вы точно хотите удалить следующих пользователей:\n";
                foreach (DataGridViewRow row in DGVUsers.SelectedRows)
                {
                    message += $"{row.Cells["Фамилия"].Value} {row.Cells["Имя"].Value}\n";
                }

                if (MessageBox.Show(message, "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (dbConnection.OpenConnection())
                        {
                            foreach (DataGridViewRow row in DGVUsers.SelectedRows)
                            {
                                int userId = Convert.ToInt32(row.Cells["UserID"].Value);
                                string query = $"DELETE FROM User WHERE UserID = {userId}";
                                MySqlCommand command = new MySqlCommand(query, dbConnection.GetConnection());
                                command.ExecuteNonQuery();
                            }
                            dbConnection.CloseConnection();
                            LoadUsers(); // Обновляем список после удаления
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при удалении пользователей: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователей для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

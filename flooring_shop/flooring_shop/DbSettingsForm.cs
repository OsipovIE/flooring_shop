using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace flooring_shop
{
    public partial class DbSettingsForm : Form
    {
        public DbSettingsForm()
        {
            InitializeComponent();
            LoadSettings();
        }
        private void LoadSettings()
        {
            txtServer.Text = ConfigurationManager.AppSettings["DbServer"];
            txtDatabase.Text = ConfigurationManager.AppSettings["DbName"];
            txtUser.Text = ConfigurationManager.AppSettings["DbUser"];
            txtPassword.Text = ConfigurationManager.AppSettings["DbPassword"];
        }

        private void TestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                string testConnectionString =
                    $"server={txtServer.Text};database={txtDatabase.Text};" +
                    $"user={txtUser.Text};password={txtPassword.Text};";

                using (var testConn = new MySqlConnection(testConnectionString))
                {
                    testConn.Open();
                    MessageBox.Show("Поключение успешно!", "Проверка подключения", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения:\n"+ex, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error) ;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings["DbServer"].Value = txtServer.Text;
                config.AppSettings.Settings["DbName"].Value = txtDatabase.Text;
                config.AppSettings.Settings["DbUser"].Value = txtUser.Text;
                config.AppSettings.Settings["DbPassword"].Value = txtPassword.Text;

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                MessageBox.Show("Настройки сохраненны!","Успех",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();

            }
            catch (Exception ex){
                MessageBox.Show($"Ошибка сохранения настроек:\n{ex.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CSVimportBTN_Click(object sender, EventArgs e)
        {

        }

        private void HealthBDbtn_Click(object sender, EventArgs e)
        {

        }
    }
}

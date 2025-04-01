using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flooring_shop
{
    public partial class Administrator : Form
    {
        public Administrator()
        {
            InitializeComponent();
        }

        public void SetAdminInfo(string userFullName)
        {
            AdminName.Text = $"Администратор - {userFullName}";
        }

        private void Administrator_Load(object sender, EventArgs e)
        {

        }

        private void Administrator_FormClosing(object sender, FormClosingEventArgs e)
        {
            Authorization authForm = new Authorization();
            authForm.Show();
        }

        private void AdminUsersBtn_Click(object sender, EventArgs e)
        {
            AdminUsersForm adminuser = new AdminUsersForm();
            this.Hide();
            adminuser.Show();
        }

        private void AdminWordBtn_Click(object sender, EventArgs e)
        {
            AdministratorWord adminword = new AdministratorWord();
            this.Hide();
            adminword.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbSettingsForm setFo = new DbSettingsForm();
            this.Hide();
            setFo.ShowDialog();
            this.Show();
        }
    }
}

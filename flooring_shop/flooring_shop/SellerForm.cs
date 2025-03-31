using System;
using System.Windows.Forms;

namespace flooring_shop
{
    public partial class SellerForm : Form
    {
        public SellerForm()
        {
            InitializeComponent();
        }

        // Метод для установки информации о пользователе
        public void SetUserInfo(string userFullName)
        {
            seller.Text = ("Продавец - " + userFullName); // Устанавливаем текст в Label
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HistorySeller orderseller = new HistorySeller();
            this.Hide();
            orderseller.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SellerOrder orderseller = new SellerOrder();
            this.Hide();
            orderseller.Show();
        }

        private void seller_Click(object sender, EventArgs e)
        {
           
        }

        private void SellerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Authorization authForm = new Authorization();
            authForm.Show();
        }
    }
}
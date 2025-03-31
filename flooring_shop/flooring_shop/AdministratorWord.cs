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
using Word = Microsoft.Office.Interop.Word;

namespace flooring_shop
{
    public partial class AdministratorWord : Form
    {
        private DatabaseConnection dbConnection;

        public AdministratorWord()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            LoadPeriods();
        }

        private void LoadPeriods()
        {
            PeriodCB.Items.AddRange(new string[] {
                "За сегодня",
                "За неделю",
                "За месяц",
                "За квартал",
                "За год",
                "За все время"
            });
            PeriodCB.SelectedIndex = 0;
        }

        private void CreateWordReport(DataTable data, DateTime startDate, DateTime endDate, decimal totalProfit)
        {
            try
            {
                Word.Application wordApp = new Word.Application();
                Word.Document wordDoc = wordApp.Documents.Add();
                wordApp.Visible = true;

                // Заголовок
                Word.Paragraph titleParagraph = wordDoc.Content.Paragraphs.Add();
                titleParagraph.Range.Text = "Отчет о прибыли с продаж";
                titleParagraph.Range.Font.Bold = 1;
                titleParagraph.Range.Font.Size = 16;
                titleParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                titleParagraph.Range.InsertParagraphAfter();

                // Период
                Word.Paragraph periodParagraph = wordDoc.Content.Paragraphs.Add();
                periodParagraph.Range.Text = $"Период: {startDate.ToShortDateString()} - {endDate.ToShortDateString()}";
                periodParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                periodParagraph.Range.InsertParagraphAfter();

                // Дата формирования
                Word.Paragraph dateParagraph = wordDoc.Content.Paragraphs.Add();
                dateParagraph.Range.Text = $"Дата формирования: {DateTime.Now.ToShortDateString()}";
                dateParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                dateParagraph.Range.InsertParagraphAfter();

                // Пустая строка
                Word.Paragraph emptyParagraph = wordDoc.Content.Paragraphs.Add();
                emptyParagraph.Range.Text = "";
                emptyParagraph.Range.InsertParagraphAfter();

                // Таблица с данными
                Word.Table table = wordDoc.Tables.Add(wordDoc.Range(wordDoc.Content.End - 1), data.Rows.Count + 1, data.Columns.Count);
                table.Borders.Enable = 1;

                // Заголовки таблицы
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    table.Cell(1, i + 1).Range.Text = data.Columns[i].ColumnName;
                    table.Cell(1, i + 1).Range.Font.Bold = 1;
                }

                // Данные таблицы
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    for (int j = 0; j < data.Columns.Count; j++)
                    {
                        table.Cell(i + 2, j + 1).Range.Text = data.Rows[i][j].ToString();
                    }
                }

                // Итоговая прибыль
                Word.Paragraph totalParagraph = wordDoc.Content.Paragraphs.Add();
                totalParagraph.Range.Text = $"Общая прибыль за период: {totalProfit:C}";
                totalParagraph.Range.Font.Bold = 1;
                totalParagraph.Range.Font.Size = 14;
                totalParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании Word-документа: " + ex.Message);
            }
        }

        private void AdministratorWord_FormClosing(object sender, FormClosingEventArgs e)
        {
            Authorization authForm = new Authorization();
            authForm.Show();
        }

        private void PeriodWordBtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate, endDate = DateTime.Now;

                switch (PeriodCB.SelectedIndex)
                {
                    case 0: // За сегодня
                        startDate = DateTime.Today;
                        break;
                    case 1: // За неделю
                        startDate = DateTime.Today.AddDays(-7);
                        break;
                    case 2: // За месяц
                        startDate = DateTime.Today.AddMonths(-1);
                        break;
                    case 3: // За квартал
                        startDate = DateTime.Today.AddMonths(-3);
                        break;
                    case 4: // За год
                        startDate = DateTime.Today.AddYears(-1);
                        break;
                    default: // За все время
                        startDate = new DateTime(2000, 1, 1);
                        break;
                }

                if (dbConnection.OpenConnection())
                {
                    string query = @"
                        SELECT 
                            `Order`.OrderID AS 'Номер заказа',
                            `Order`.OrderDate AS 'Дата заказа',
                            SUM(Product.ProductCost * OrderProduct.ProdNumCount) AS 'Сумма заказа'
                        FROM `Order`
                        JOIN OrderProduct ON `Order`.OrderID = OrderProduct.OrderID
                        JOIN Product ON OrderProduct.ProductArticleNumber = Product.ProductArticleNumber
                        WHERE `Order`.OrderDate BETWEEN @StartDate AND @EndDate
                        GROUP BY `Order`.OrderID, `Order`.OrderDate";

                    MySqlCommand command = new MySqlCommand(query, dbConnection.GetConnection());
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    decimal totalProfit = 0;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        totalProfit += Convert.ToDecimal(row["Сумма заказа"]);
                    }

                    CreateWordReport(dataTable, startDate, endDate, totalProfit);
                    dbConnection.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при формировании отчета: " + ex.Message);
            }
        }
    }
}
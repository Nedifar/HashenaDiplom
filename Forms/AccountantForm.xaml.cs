using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OxyPlot.Wpf;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using ClosedXML.Excel;

namespace Project.Forms
{
    /// <summary>
    /// Логика взаимодействия для AccountantForm.xaml
    /// </summary>
    public partial class AccountantForm : UserControl
    {
        public AccountantForm()
        {
            InitializeComponent();
            cbGr.ItemsSource = new string[] { "Прирост покупателей", "Купленные продукты", "Оказанные услуги" };
        }

        private void cbGr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbGr.SelectedIndex)
            {
                case 0:
                    {
                        //var list = Models.context.AgetDB().Buyers.ToList();
                        //var r = list.GroupBy(p => p.dateRegistr.Date).Select(p => new { Name = p.Key.Date, Count = p.Count() });
                        //PlotModel plotModel = new PlotModel();
                        //var listBar = new List<Item>();
                        //var massiv = new List<string>();

                        //foreach(var rr in r)
                        //{
                        //    listBar.Add(new Item { Value = rr.Count });
                        //    massiv.Add(rr.Name.ToShortDateString());
                        //}
                        //plotModel.Series.Add(new LineSeries
                        //{  ItemsSource = listBar });

                        //plotModel.Axes.Add( new CategoryAxis
                        //{
                        //    Position = AxisPosition.Bottom,
                        //    ItemsSource = massiv
                        //});
                        //pl.Model = plotModel;
                        break;
                    }
                default:
                    break;
            }
        }

        private void clCSV(object sender, RoutedEventArgs e)
        {
            var list = Models.context.AgetDB().Orders.ToList();
            var resList = new List<toCsv>();
            foreach (var item in list)
            {
                resList.Add(new toCsv { Buyer = item.Buyer.fullName, dateClosed = item.dateClosed, dateCreated = item.dateCreated, Employee = item.Employee.fullName, fullPrice = item.fullPrice, idOrder = item.idOrder, Service = item.Service.name, status = item.status, fullOrder = item.getProductsList });
            }
            ////before your loop
            //var csv = new StringBuilder();
            XLWorkbook lWorkbook = new XLWorkbook();
            var worksheet = lWorkbook.Worksheets.Add("FirstSheet");
            worksheet.Cell(1, 1).Value = "Номер заказа";
            worksheet.Cell(1, 2).Value = "Сотрудник";
            worksheet.Cell(1, 3).Value = "Услуга";
            worksheet.Cell(1, 4).Value = "Дата создания";
            worksheet.Cell(1, 5).Value = "Дата закрытия";
            worksheet.Cell(1, 6).Value = "Полная цена";
            worksheet.Cell(1, 7).Value = "Покупатель";
            worksheet.Cell(1, 8).Value = "Список изделий";
            for (int i = 0;i<resList.Count; i++)
            {
                worksheet.Cell(i + 2, 2).DataType = XLDataType.Text;
                worksheet.Cell(i+2, 1).Value = resList[i].idOrder;
                worksheet.Cell(i + 2, 2).Value = resList[i].Employee;
                worksheet.Cell(i+2, 3).Value = resList[i].Service;
                worksheet.Cell(i+2, 4).Value = resList[i].dateCreated;
                worksheet.Cell(i+2, 5).Value = resList[i].dateClosed;
                worksheet.Cell(i+2, 6).Value = resList[i].fullPrice;
                worksheet.Cell(i+2, 7).Value = resList[i].Buyer;
                worksheet.Cell(i+2, 8).Value = resList[i].fullOrder;
                
            }
            lWorkbook.SaveAs($"{AppDomain.CurrentDomain.BaseDirectory}Reports\\{DateTime.Now.ToShortDateString()}.xlsx");
            MessageBox.Show("Отчет сохранен по пути корень приложения/Reports", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        class toCsv
        {
            public int idOrder { get; set; }
            public string Employee { get; set; }
            public string Service { get; set; }
            public string status { get; set; }
            public DateTime? dateCreated { get; set; }
            public DateTime? dateClosed { get; set; }
            public double fullPrice { get; set; }
            public string Buyer { get; set; }
            public string fullOrder { get; set; }
        }
    }
}

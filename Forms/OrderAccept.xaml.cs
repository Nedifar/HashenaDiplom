using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Project.Forms
{
    /// <summary>
    /// Логика взаимодействия для OrderAccept.xaml
    /// </summary>
    public partial class OrderAccept : Window
    {
        Models.Order order;
        public OrderAccept(Models.Order or)
        {
            InitializeComponent();
            order = or;
        }

        private void clClick(object sender, RoutedEventArgs e)
        {
            try
            {
                order.status = "В процессе";
                order.plan = int.Parse(tbPlan.Text);
                Models.context.AgetDB().SaveChanges();
                MessageBox.Show("Работа началась.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch
            { MessageBox.Show("Проверьте корректность введенных данных.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information); }
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project.Forms
{
    /// <summary>
    /// Логика взаимодействия для OrderTechnikForm.xaml
    /// </summary>
    public partial class OrderTechnikForm : UserControl
    {
        public OrderTechnikForm()
        {
            InitializeComponent();
            dgOrder.ItemsSource = Models.context.AgetDB().Orders.Where(p=>p.OrderProducts.Count()!=0 && (p.status== "В процессе" || p.status == "Ожидает выполнения.")).OrderByDescending(p => p.idOrder).ToList();
        }

        private void clStatus(object sender, RoutedEventArgs e)
        {
            var sens = (sender as Button).DataContext as Models.Order;
            var accept = new OrderAccept(sens);
            accept.Show();
            accept.IsVisibleChanged += Accept_IsVisibleChanged;
            
        }

        private void clComplet(object sender, RoutedEventArgs e)
        {
            var sens = (sender as Button).DataContext as Models.Order;
            sens.dateClosed = DateTime.Now;
            sens.status = "Завершена";
            Models.context.AgetDB().SaveChanges();
            dgOrder.ItemsSource = Models.context.AgetDB().Orders.Where(p => p.OrderProducts.Count() != 0 && (p.status == "В процессе" || p.status == "Ожидает выполнения.")).OrderByDescending(p => p.idOrder).ToList();
            MessageBox.Show("Заказ завершен.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Accept_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            dgOrder.ItemsSource = Models.context.AgetDB().Orders.Where(p=>p.OrderProducts.Count()!=0 && (p.status== "В процессе" || p.status == "Ожидает выполнения.")).OrderByDescending(p => p.idOrder).ToList();

        }
    }
}

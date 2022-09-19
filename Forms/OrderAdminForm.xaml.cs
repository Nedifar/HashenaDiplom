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
    /// Логика взаимодействия для OrderAdminForm.xaml
    /// </summary>
    public partial class OrderAdminForm : UserControl
    {
        public OrderAdminForm()
        {
            InitializeComponent();
            dgOrder.ItemsSource = Models.context.AgetDB().Orders.OrderByDescending(p=>p.idOrder).ToList();
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void Search(object sender, TextChangedEventArgs e)
        {

        }

        private void clStatus(object sender, RoutedEventArgs e)
        {
            var sens = (sender as Button).DataContext as Models.Order;
            sens.dateClosed = DateTime.Now;
            sens.status = "Закрыта";
            Models.context.AgetDB().SaveChanges();
            MessageBox.Show("Заказ закрыт.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

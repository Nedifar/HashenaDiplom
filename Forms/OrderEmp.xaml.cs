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
    /// Логика взаимодействия для OrderEmp.xaml
    /// </summary>
    public partial class OrderEmp : UserControl
    {
        public OrderEmp()
        {
            InitializeComponent();
            dgOrder.ItemsSource = Models.context.AgetDB().Orders.OrderByDescending(p => p.idOrder).ToList();
        }

        private void clAdd(object sender, RoutedEventArgs e)
        {
            EditBuyer editProduct = new EditBuyer(null, "ordEmp");
            Models.LightClass.main.gridM.Children.Clear();
            Models.LightClass.main.gridM.Children.Add(editProduct);
        }

        private void clNewOrder(object sender, RoutedEventArgs e)
        {
            newOrder newOrder = new newOrder();
            Models.LightClass.EmpOrder = newOrder;
            Models.LightClass.main.gridM.Children.Clear();
            Models.LightClass.main.gridM.Children.Add(newOrder);
        }

        private void clReport(object sender, RoutedEventArgs e)
        {

        }
    }
}

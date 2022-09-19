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
    /// Логика взаимодействия для newOrder.xaml
    /// </summary>
    public partial class newOrder : UserControl
    {
        Models.Order NewOrder = new Models.Order();
        List<Models.OrderProduct> serv = new List<Models.OrderProduct>();

        public newOrder()
        {
            InitializeComponent();
            cbProduct.ItemsSource = Models.context.AgetDB().Products.ToList();
            cbService.ItemsSource = Models.context.AgetDB().Services.ToList();
        }


        private void clFinishOrder(object sender, RoutedEventArgs e)
        {
            try
            {
                double price = 0;
                string last = Name.Text.Split(' ')[0];
                string first = Name.Text.Split(' ')[1];
                string midlle = Name.Text.Split(' ')[2];
                NewOrder.Buyer = Models.context.AgetDB().Buyers.Where(p => p.lastName == last && p.firstName == first && p.midlleName == midlle).FirstOrDefault();
                if(NewOrder.Buyer == null)
                {
                    var messRes = MessageBox.Show("Такого покупателя не существует, хотите его создать?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (messRes == MessageBoxResult.Yes)
                    {
                        EditBuyer edit = new EditBuyer(null, "new");
                        Models.LightClass.main.gridM.Children.Clear();
                        Models.LightClass.main.gridM.Children.Add(edit);
                        return;
                    }
                    else
                        return;
                }
                NewOrder.Employee = Models.LightClass.Employee;
                NewOrder.Service = cbService.SelectedItem as Models.Service;
                NewOrder.status = "Ожидает выполнения.";
                NewOrder.dateCreated = DateTime.Now;
                foreach (ComboBox box in spServices.Children)
                {
                    serv.Add(new Models.OrderProduct { Product = (Models.Product)(box).SelectedItem });
                }
                foreach (var pr in serv)
                {
                    price += pr.Product.cost;
                }
                NewOrder.fullPrice = price;
                NewOrder.OrderProducts.AddRange(serv);
                Models.context.AgetDB().Orders.Add(NewOrder);
                Models.context.AgetDB().SaveChanges();
                serv.Clear();
                MessageBox.Show("Сохранено", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                Models.LightClass.main.gridM.Children.Clear();
                Models.LightClass.main.gridM.Children.Add(new OrderEmp());
            }
            catch
            { MessageBox.Show("Ошибка", "Информация", MessageBoxButton.OK, MessageBoxImage.Information); }
        }

        private void addNewLabelForService(object sender, RoutedEventArgs e)
        {
            ComboBox combo = new ComboBox();
            combo.DropDownClosed += cbProduct_DropDownClosed;
            combo.DropDownOpened += cbProduct_DropDownOpened;
            spServices.Children.Add(combo);
            combo.DisplayMemberPath = "name";
            combo.ItemsSource = Models.context.AgetDB().Products.ToList();
        }

        private void cl_Back(object sender, RoutedEventArgs e)
        {
            Models.LightClass.main.gridM.Children.Clear();
            Models.LightClass.main.gridM.Children.Add(new OrderEmp());
        }

        private void cbProduct_DropDownOpened(object sender, EventArgs e)
        {
            (sender as ComboBox).Foreground = Brushes.Black;
        }

        private void cbProduct_DropDownClosed(object sender, EventArgs e)
        {
            (sender as ComboBox).Foreground = Brushes.White;
        }
    }
}

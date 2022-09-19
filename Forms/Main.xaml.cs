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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Models.Employee prEmployee;
        public Main(Models.Employee emp, string bb)
        {
            InitializeComponent();
            clEvrazia(null, null);
            prEmployee = emp;
            if(prEmployee ==null && bb == "") { NavigationControlsVisibleChange(6); }
            else if (bb == "") { NavigationControlsVisibleChange(emp.idDepartament); }
            else { NavigationControlsVisibleChange(0); }
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void clExit(object sender, RoutedEventArgs e)
        {
            new SignForm().Show();
            Close();
        }

        public void Back(ContentControl cont)
        {
            gridM.Children.Clear();
            gridM.Children.Add(cont);
        }


        private void clEvrazia(object sender, RoutedEventArgs e)
        {
            btDep.Foreground = Brushes.LightGray;
            btEmp.Foreground = Brushes.LightGray;
            btSer.Foreground = Brushes.LightGray;
            btOrder.Foreground = Brushes.LightGray;
            btProducts.Foreground = Brushes.LightGray;
            btBuyer.Foreground = Brushes.LightGray;
            btHistory.Foreground = Brushes.LightGray;
            btEvrazia.Foreground = Brushes.White;
            btOrderEmp.Foreground = Brushes.LightGray;
            gridM.Children.Clear();
            gridM.Children.Add(new MainControl());
        }

        private void NavigationControlsVisibleChange(int id)
        {
            switch (id)
            {
                case 0:
                    btDep.Visibility = Visibility.Collapsed;
                    btEmp.Visibility = Visibility.Collapsed;
                    btSer.Visibility = Visibility.Collapsed;
                    btOrder.Visibility = Visibility.Collapsed;
                    btProducts.Visibility = Visibility.Collapsed;
                    btBuyer.Visibility = Visibility.Collapsed;
                    btHistory.Visibility = Visibility.Collapsed;
                    btOrderEmp.Visibility = Visibility.Collapsed;
                    btReq.Visibility = Visibility.Collapsed;
                    btEveAdmin.Visibility = Visibility.Collapsed;
                    btEventsEmp.Visibility = Visibility.Collapsed;
                    btOrderTech.Visibility = Visibility.Collapsed;
                    btRep.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    btDep.Visibility = Visibility.Collapsed;
                    btEmp.Visibility = Visibility.Collapsed;
                    btSer.Visibility = Visibility.Collapsed;
                    btOrder.Visibility = Visibility.Collapsed;
                    btProducts.Visibility = Visibility.Collapsed;
                    btBuyer.Visibility = Visibility.Collapsed;
                    btHistory.Visibility = Visibility.Collapsed;
                    btOrderEmp.Visibility = Visibility.Collapsed;
                    btReq.Visibility = Visibility.Collapsed;
                    btMessagesB.Visibility = Visibility.Collapsed;
                    btServiceB.Visibility = Visibility.Collapsed;
                    btProductsB.Visibility = Visibility.Collapsed;
                    btEveAdmin.Visibility = Visibility.Collapsed;
                    btRep.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    btDep.Visibility = Visibility.Collapsed;
                    btEmp.Visibility = Visibility.Collapsed;
                    btSer.Visibility = Visibility.Collapsed;
                    btOrder.Visibility = Visibility.Collapsed;
                    btProducts.Visibility = Visibility.Collapsed;
                    btBuyer.Visibility = Visibility.Collapsed;
                    btHistory.Visibility = Visibility.Collapsed;
                    btOrderTech.Visibility = Visibility.Collapsed;
                    btReq.Visibility = Visibility.Collapsed;
                    btMessagesB.Visibility = Visibility.Collapsed;
                    btServiceB.Visibility = Visibility.Collapsed;
                    btProductsB.Visibility = Visibility.Collapsed;
                    btEveAdmin.Visibility = Visibility.Collapsed;
                    btRep.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    btDep.Visibility = Visibility.Collapsed;
                    btEmp.Visibility = Visibility.Collapsed;
                    btSer.Visibility = Visibility.Collapsed;
                    btOrder.Visibility = Visibility.Collapsed;
                    btProducts.Visibility = Visibility.Collapsed;
                    btBuyer.Visibility = Visibility.Collapsed;
                    btHistory.Visibility = Visibility.Collapsed;
                    btOrderTech.Visibility = Visibility.Collapsed;
                    btOrderEmp.Visibility = Visibility.Collapsed;
                    btReq.Visibility = Visibility.Collapsed;
                    btMessagesB.Visibility = Visibility.Collapsed;
                    btServiceB.Visibility = Visibility.Collapsed;
                    btProductsB.Visibility = Visibility.Collapsed;
                    btEveAdmin.Visibility = Visibility.Collapsed;
                    break;
                case 5:
                    btDep.Visibility = Visibility.Collapsed;
                    btEmp.Visibility = Visibility.Collapsed;
                    btSer.Visibility = Visibility.Collapsed;
                    btOrder.Visibility = Visibility.Collapsed;
                    btProducts.Visibility = Visibility.Collapsed;
                    btBuyer.Visibility = Visibility.Collapsed;
                    btHistory.Visibility = Visibility.Collapsed;
                    btOrderTech.Visibility = Visibility.Collapsed;
                    btOrderEmp.Visibility = Visibility.Collapsed;
                    btMessagesB.Visibility = Visibility.Collapsed;
                    btServiceB.Visibility = Visibility.Collapsed;
                    btProductsB.Visibility = Visibility.Collapsed;
                    btEveAdmin.Visibility = Visibility.Collapsed;
                    btRep.Visibility = Visibility.Collapsed;
                    break;
                case 6:
                    btOrderTech.Visibility = Visibility.Collapsed;
                    btOrderEmp.Visibility = Visibility.Collapsed;
                    btReq.Visibility = Visibility.Collapsed;
                    btMessagesB.Visibility = Visibility.Collapsed;
                    btServiceB.Visibility = Visibility.Collapsed;
                    btProductsB.Visibility = Visibility.Collapsed;
                    btEventsEmp.Visibility = Visibility.Collapsed;
                    btRep.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void clBuyer(object sender, RoutedEventArgs e)
        {
            btDep.Foreground = Brushes.LightGray;
            btEmp.Foreground = Brushes.LightGray;
            btSer.Foreground = Brushes.LightGray;
            btOrder.Foreground = Brushes.LightGray;
            btProducts.Foreground = Brushes.LightGray;
            btBuyer.Foreground = Brushes.White;
            btHistory.Foreground = Brushes.LightGray;
            btEvrazia.Foreground = Brushes.LightGray;
            btOrderEmp.Foreground = Brushes.LightGray;
            btEveAdmin.Foreground = Brushes.LightGray;
            gridM.Children.Clear();
            gridM.Children.Add(new BuyersForm());
        }

        private void clEmp(object sender, RoutedEventArgs e)
        {
            btDep.Foreground = Brushes.LightGray;
            btEmp.Foreground = Brushes.White;
            btSer.Foreground = Brushes.LightGray;
            btOrder.Foreground = Brushes.LightGray;
            btProducts.Foreground = Brushes.LightGray;
            btBuyer.Foreground = Brushes.LightGray;
            btHistory.Foreground = Brushes.LightGray;
            btEvrazia.Foreground = Brushes.LightGray;
            btOrderEmp.Foreground = Brushes.LightGray;
            btEveAdmin.Foreground = Brushes.LightGray;
            gridM.Children.Clear();
            gridM.Children.Add(new EmpForm());
        }

        private void clHistory(object sender, RoutedEventArgs e)
        {
            btDep.Foreground = Brushes.LightGray;
            btEmp.Foreground = Brushes.LightGray;
            btSer.Foreground = Brushes.LightGray;
            btOrder.Foreground = Brushes.LightGray;
            btProducts.Foreground = Brushes.LightGray;
            btBuyer.Foreground = Brushes.LightGray;
            btHistory.Foreground = Brushes.White;
            btEvrazia.Foreground = Brushes.LightGray;
            btOrderEmp.Foreground = Brushes.LightGray;
            btEveAdmin.Foreground = Brushes.LightGray;
            gridM.Children.Clear();
            gridM.Children.Add(new LogsForm());
        }

        private void clOrder(object sender, RoutedEventArgs e)
        {
            btDep.Foreground = Brushes.LightGray;
            btEmp.Foreground = Brushes.LightGray;
            btSer.Foreground = Brushes.LightGray;
            btOrder.Foreground = Brushes.White;
            btProducts.Foreground = Brushes.LightGray;
            btBuyer.Foreground = Brushes.LightGray;
            btHistory.Foreground = Brushes.LightGray;
            btEvrazia.Foreground = Brushes.LightGray;
            btOrderEmp.Foreground = Brushes.LightGray;
            btEveAdmin.Foreground = Brushes.LightGray;
            gridM.Children.Clear();
            gridM.Children.Add(new OrderAdminForm());
        }

        private void clProduct(object sender, RoutedEventArgs e)
        {
            btDep.Foreground = Brushes.LightGray;
            btEmp.Foreground = Brushes.LightGray;
            btSer.Foreground = Brushes.LightGray;
            btOrder.Foreground = Brushes.LightGray;
            btProducts.Foreground = Brushes.White;
            btBuyer.Foreground = Brushes.LightGray;
            btHistory.Foreground = Brushes.LightGray;
            btEvrazia.Foreground = Brushes.LightGray;
            btOrderEmp.Foreground = Brushes.LightGray;
            btEveAdmin.Foreground = Brushes.LightGray;
            gridM.Children.Clear();
            gridM.Children.Add(new ProductForm());
        }

        private void clDep(object sender, RoutedEventArgs e)
        {
            btDep.Foreground = Brushes.White;
            btEmp.Foreground = Brushes.LightGray;
            btSer.Foreground = Brushes.LightGray;
            btOrder.Foreground = Brushes.LightGray;
            btProducts.Foreground = Brushes.LightGray;
            btBuyer.Foreground = Brushes.LightGray;
            btHistory.Foreground = Brushes.LightGray;
            btEvrazia.Foreground = Brushes.LightGray;
            btOrderEmp.Foreground = Brushes.LightGray;
            btEveAdmin.Foreground = Brushes.LightGray;
            gridM.Children.Clear();
            gridM.Children.Add(new Departament());
        }

        private void clSer(object sender, RoutedEventArgs e)
        {
            btDep.Foreground = Brushes.LightGray;
            btEmp.Foreground = Brushes.LightGray;
            btSer.Foreground = Brushes.White;
            btOrder.Foreground = Brushes.LightGray;
            btProducts.Foreground = Brushes.LightGray;
            btBuyer.Foreground = Brushes.LightGray;
            btHistory.Foreground = Brushes.LightGray;
            btEvrazia.Foreground = Brushes.LightGray;
            btOrderEmp.Foreground = Brushes.LightGray;
            btEveAdmin.Foreground = Brushes.LightGray;
            gridM.Children.Clear();
            gridM.Children.Add(new ServiceForm());
        }

        private void clOrderEmp(object sender, RoutedEventArgs e)
        {
            btEvrazia.Foreground = Brushes.LightGray;
            btOrderEmp.Foreground = Brushes.White;
            btEventsEmp.Foreground = Brushes.LightGray;
            gridM.Children.Clear();
            gridM.Children.Add(new OrderEmp());
        }

        private void clOrderTech(object sender, RoutedEventArgs e)
        {
            btEvrazia.Foreground = Brushes.LightGray;
            btOrderTech.Foreground = Brushes.White;
            btEventsEmp.Foreground = Brushes.LightGray;
            gridM.Children.Clear();
            gridM.Children.Add(new OrderTechnikForm());
        }

        private void clReq(object sender, RoutedEventArgs e)
        {
            btEvrazia.Foreground = Brushes.LightGray;
            btReq.Foreground = Brushes.White;
            btEventsEmp.Foreground = Brushes.LightGray;
            gridM.Children.Clear();
            gridM.Children.Add(new Requests());
        }

        private void clProductB(object sender, RoutedEventArgs e)
        {
            btEvrazia.Foreground = Brushes.LightGray;
            btServiceB.Foreground = Brushes.LightGray;
            btMessagesB.Foreground = Brushes.LightGray;
            btProductsB.Foreground = Brushes.White;
            btEventsEmp.Foreground = Brushes.LightGray;
            gridM.Children.Clear();
            gridM.Children.Add(new ProductsBuyer());
        }

        private void clSerB(object sender, RoutedEventArgs e)
        {
            btEvrazia.Foreground = Brushes.LightGray;
            btServiceB.Foreground = Brushes.White;
            btMessagesB.Foreground = Brushes.LightGray;
            btProductsB.Foreground = Brushes.LightGray;
            btEventsEmp.Foreground = Brushes.LightGray;
            gridM.Children.Clear();
            gridM.Children.Add(new ServiceBuyer());
        }

        private void clMessagesB(object sender, RoutedEventArgs e)
        {
            btEvrazia.Foreground = Brushes.LightGray;
            btServiceB.Foreground = Brushes.LightGray;
            btMessagesB.Foreground = Brushes.White;
            btProductsB.Foreground = Brushes.LightGray;
            gridM.Children.Clear();
            gridM.Children.Add(new MessagesBuyer());
        }

        private void clEvEmp(object sender, RoutedEventArgs e)
        {
            gridM.Children.Clear();
            gridM.Children.Add(new EventPage(prEmployee.idDepartament));
        }

        private void clEveAdmin(object sender, RoutedEventArgs e)
        {
            btDep.Foreground = Brushes.LightGray;
            btEmp.Foreground = Brushes.LightGray;
            btSer.Foreground = Brushes.LightGray;
            btOrder.Foreground = Brushes.LightGray;
            btProducts.Foreground = Brushes.LightGray;
            btBuyer.Foreground = Brushes.LightGray;
            btHistory.Foreground = Brushes.LightGray;
            btEvrazia.Foreground = Brushes.LightGray;
            btOrderEmp.Foreground = Brushes.LightGray;
            btEveAdmin.Foreground = Brushes.White;
            gridM.Children.Clear();
            gridM.Children.Add(new EventPage(0));
        }

        private void clRep(object sender, RoutedEventArgs e)
        {
            btHistory.Foreground = Brushes.LightGray;
            btEvrazia.Foreground = Brushes.LightGray;
            btRep.Foreground = Brushes.White;
            gridM.Children.Clear();
            gridM.Children.Add(new AccountantForm());
        }
    }
}

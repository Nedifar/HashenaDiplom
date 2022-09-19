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
    /// Логика взаимодействия для EditBuyer.xaml
    /// </summary>
    public partial class EditBuyer : UserControl
    {
        string res = String.Empty;
        Models.Buyer selectedBuyer = new Models.Buyer();
        public EditBuyer(Models.Buyer buyer, string ede)
        {
            InitializeComponent();
            if (buyer != null)
                selectedBuyer = buyer;
            res = ede;
            DataContext = selectedBuyer;
        }

        private void clSave(object sender, RoutedEventArgs e)
        {
            if (selectedBuyer.idBuyer == 0)
            {
                selectedBuyer.dateRegistr = DateTime.Now;
                Models.context.AgetDB().Buyers.Add(selectedBuyer);
            }
            Models.context.AgetDB().SaveChanges();
            MessageBox.Show("Сохранение успешно завершено.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            Models.LightClass.main.gridM.Children.Clear();
            if(res == "ordEmp")
                Models.LightClass.main.gridM.Children.Add(new OrderEmp());
            else if(res == "new")
            {
                Models.LightClass.main.gridM.Children.Add(Models.LightClass.EmpOrder);
            }
            else
                Models.LightClass.main.gridM.Children.Add(new BuyersForm());
        }

        private void cl_Back(object sender, RoutedEventArgs e)
        {
            Models.LightClass.main.gridM.Children.Clear();
            Models.LightClass.main.gridM.Children.Add(new BuyersForm());
        }
    }
}

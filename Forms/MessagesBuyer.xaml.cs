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
    /// Логика взаимодействия для MessagesBuyer.xaml
    /// </summary>
    public partial class MessagesBuyer : UserControl
    {
        public MessagesBuyer()
        {
            InitializeComponent();
            dgOrder.ItemsSource = Models.context.AgetDB().Qestions.Where(p => p.idBuyer == Models.LightClass.buyer.idBuyer && p.status != "Закрыт").ToList();
        }

        private void clReply(object sender, RoutedEventArgs e)
        {
            var sens = (sender as Button).DataContext as Models.Qestion;
            sens.status = "Закрыт";
            Models.context.AgetDB().SaveChanges();
            (sender as Button).Visibility = Visibility.Collapsed;
        }

        private void clWrite(object sender, RoutedEventArgs e)
        {
            Models.LightClass.main.gridM.Children.Clear();
            Models.LightClass.main.gridM.Children.Add(new WriteCPP());
        }
    }
}

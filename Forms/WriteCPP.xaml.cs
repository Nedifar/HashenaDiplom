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
    /// Логика взаимодействия для WriteCPP.xaml
    /// </summary>
    public partial class WriteCPP : UserControl
    {
        Models.Qestion qestion = new Models.Qestion();
        public WriteCPP()
        {
            InitializeComponent();
            DataContext = qestion;
        }

        private void clSave(object sender, RoutedEventArgs e)
        {
            qestion.idBuyer = Models.LightClass.buyer.idBuyer;
            qestion.status = "Ожидает ответа";
            Models.context.AgetDB().Qestions.Add(qestion);
            Models.context.AgetDB().SaveChanges();
            MessageBox.Show("Сообщение отправлено в ЦПП на рассмотрение.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            Models.LightClass.main.gridM.Children.Clear();
            Models.LightClass.main.gridM.Children.Add(new MessagesBuyer());
        }

        private void cl_Back(object sender, RoutedEventArgs e)
        {
            Models.LightClass.main.gridM.Children.Clear();
            Models.LightClass.main.gridM.Children.Add(new MessagesBuyer());
        }
    }
}

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
    /// Логика взаимодействия для Requests.xaml
    /// </summary>
    public partial class Requests : UserControl
    {
        public Requests()
        {
            InitializeComponent();
            dgOrder.ItemsSource = Models.context.AgetDB().Qestions.Where(p=>p.status =="Ожидает ответа").ToList();
        }

        private void clReply(object sender, RoutedEventArgs e)
        {
            var sens = (sender as Button).DataContext as Models.Qestion;
            Forms.AnswearCompleted completed = new AnswearCompleted(sens);
            Models.LightClass.main.gridM.Children.Clear();
            Models.LightClass.main.gridM.Children.Add(completed);
        }
    }
}

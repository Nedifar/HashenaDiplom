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
    /// Логика взаимодействия для AnswearCompleted.xaml
    /// </summary>
    public partial class AnswearCompleted : UserControl
    {
        Models.Qestion qestion;
        public AnswearCompleted(Models.Qestion _qestion)
        {
            InitializeComponent();
            qestion = _qestion;
            DataContext = qestion;
        }

        private void cl_Back(object sender, RoutedEventArgs e)
        {
            Models.LightClass.main.gridM.Children.Clear();
            Models.LightClass.main.gridM.Children.Add(new Requests());
        }

        private void clSave(object sender, RoutedEventArgs e)
        {
            qestion.status = "Ожидает прочтения";
            Models.context.AgetDB().SaveChanges();
            MessageBox.Show("Ответ успешно отправлен.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            cl_Back(null, null);
        }
    }
}

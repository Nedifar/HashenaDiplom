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
    /// Логика взаимодействия для EditSer.xaml
    /// </summary>
    public partial class EditSer : UserControl
    {
        Models.Service selectedService = new Models.Service();
        public EditSer(Models.Service ser)
        {
            InitializeComponent();
            if (ser != null)
                selectedService = ser;
            cbE.ItemsSource = Models.context.AgetDB().Departaments.ToList();
            DataContext = selectedService;
        }

        private void clSave(object sender, RoutedEventArgs e)
        {
            if (selectedService.idService == 0)
                Models.context.AgetDB().Services.Add(selectedService);
            Models.context.AgetDB().SaveChanges();
            MessageBox.Show("Сохранение успешно завершено.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            Models.LightClass.main.gridM.Children.Clear();
            Models.LightClass.main.gridM.Children.Add(new ServiceForm());
        }

        private void cl_Back(object sender, RoutedEventArgs e)
        {
            Models.LightClass.main.gridM.Children.Clear();
            Models.LightClass.main.gridM.Children.Add(new ServiceForm());
        }

        private void cbE_DropDownClosed(object sender, EventArgs e)
        {
            cbE.Foreground = Brushes.White;

        }

        private void cbE_DropDownOpened(object sender, EventArgs e)
        {
            cbE.Foreground = Brushes.Black;
        }
    }
}

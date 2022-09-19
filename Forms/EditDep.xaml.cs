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
    /// Логика взаимодействия для EditDep.xaml
    /// </summary>
    public partial class EditDep : UserControl
    {
        Models.Departament selectedDepartament = new Models.Departament();
        public EditDep(Models.Departament departament)
        {
            InitializeComponent();
            if (departament != null)
                selectedDepartament = departament;
            DataContext = selectedDepartament;
        }

        private void clSave(object sender, RoutedEventArgs e)
        {
            if (selectedDepartament.idDepartament == 0)
                Models.context.AgetDB().Departaments.Add(selectedDepartament);
            Models.context.AgetDB().SaveChanges();
            MessageBox.Show("Сохранение успешно завершено.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            Models.LightClass.main.gridM.Children.Clear();
            Models.LightClass.main.gridM.Children.Add(new Departament());
        }

        private void cl_Back(object sender, RoutedEventArgs e)
        {
            Models.LightClass.main.gridM.Children.Clear();
            Models.LightClass.main.gridM.Children.Add(new Departament());
        }
    }
}

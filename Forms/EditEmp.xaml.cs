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
    /// Логика взаимодействия для EditEmp.xaml
    /// </summary>
    public partial class EditEmp : UserControl
    {
        Models.Employee selectedEmployee = new Models.Employee();
        public EditEmp(Models.Employee emp)
        {
            InitializeComponent();
            if (emp != null)
                selectedEmployee = emp;
            cbE.ItemsSource = Models.context.AgetDB().Departaments.ToList();
            DataContext = selectedEmployee;
        }

        private void clSave(object sender, RoutedEventArgs e)
        {
            if (selectedEmployee.idEmployee == 0)
                Models.context.AgetDB().Employees.Add(selectedEmployee);
            Models.context.AgetDB().SaveChanges();
            MessageBox.Show("Сохранение успешно завершено.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            Models.LightClass.main.gridM.Children.Clear();
            Models.LightClass.main.gridM.Children.Add(new EmpForm());
        }

        private void cl_Back(object sender, RoutedEventArgs e)
        {
            Models.LightClass.main.gridM.Children.Clear();
            Models.LightClass.main.gridM.Children.Add(new EmpForm());
        }
    }
}

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
    /// Логика взаимодействия для EmpForm.xaml
    /// </summary>
    public partial class EmpForm : UserControl
    {
        public EmpForm()
        {
            InitializeComponent();
            dgOrder.ItemsSource = Models.context.AgetDB().Employees.ToList();
        }

        private void clDelete(object sender, RoutedEventArgs e)
        {
            if (dgOrder.SelectedItems.Count != 0)
            {
                var model = dgOrder.SelectedItem as Models.Employee;
                Models.context.AgetDB().Employees.Remove(model);
            }
            else
                MessageBox.Show("Пожалуйста, выберите 1 объект для удаления.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void clAdd(object sender, RoutedEventArgs e)
        {
            EditEmp editProduct = new EditEmp(null);
            editProduct.IsVisibleChanged += EditProduct_IsVisibleChanged;
            Models.LightClass.main.gridM.Children.Clear();
            Models.LightClass.main.gridM.Children.Add(editProduct);
        }

        private void EditProduct_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            dgOrder.ItemsSource = Models.context.AgetDB().Employees.ToList();
        }

        private void clEdit(object sender, RoutedEventArgs e)
        {
            var model = (sender as Button).DataContext as Models.Employee;
            EditEmp editProduct = new EditEmp(model);
            editProduct.IsVisibleChanged += EditProduct_IsVisibleChanged;
            Models.LightClass.main.gridM.Children.Clear();
            Models.LightClass.main.gridM.Children.Add(editProduct);
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }
    }
}

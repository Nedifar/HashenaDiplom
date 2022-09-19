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
    /// Логика взаимодействия для ServiceForm.xaml
    /// </summary>
    public partial class ServiceForm : UserControl
    {
        public ServiceForm()
        {
            InitializeComponent();
            dgOrder.ItemsSource = Models.context.AgetDB().Services.ToList();
        }

        private void clDelete(object sender, RoutedEventArgs e)
        {
            if (dgOrder.SelectedItems.Count != 0)
            {
                var model = dgOrder.SelectedItem as Models.Service;
                Models.context.AgetDB().Services.Remove(model);
            }
            else
                MessageBox.Show("Пожалуйста, выберите 1 объект для удаления.");
        }

        private void clAdd(object sender, RoutedEventArgs e)
        {
            EditSer editProduct = new EditSer(null);
            editProduct.IsVisibleChanged += EditProduct_IsVisibleChanged;
            Models.LightClass.main.gridM.Children.Clear();
            Models.LightClass.main.gridM.Children.Add(editProduct);
        }

        private void EditProduct_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            dgOrder.ItemsSource = Models.context.AgetDB().Services.ToList();
        }

        private void clEdit(object sender, RoutedEventArgs e)
        {
            var model = (sender as Button).DataContext as Models.Service;
            EditSer editProduct = new EditSer(model);
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

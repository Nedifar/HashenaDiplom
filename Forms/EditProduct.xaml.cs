using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для EditProduct.xaml
    /// </summary>
    public partial class EditProduct : UserControl
    {
        Models.Product selectedProduct = new Models.Product();
        public EditProduct(Models.Product product)
        {
            InitializeComponent();
            if (product != null)
                selectedProduct = product;
            DataContext = selectedProduct;
            cbEnergy.ItemsSource = Models.context.AgetDB().EnergyEfficiencies.ToList();
        }

        private void clSave(object sender, RoutedEventArgs e)
        {
            if (selectedProduct.photo != null && !File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}images/{selectedProduct.photo}"))
            {
                string path = imgPerson.Source.ToString().Replace("file:///", "").Replace("}", "");
                File.Copy(path, $"{AppDomain.CurrentDomain.BaseDirectory}images/{selectedProduct.photo}");
            }
            if (selectedProduct.idProduct == 0)
                Models.context.AgetDB().Products.Add(selectedProduct);
            Models.context.AgetDB().SaveChanges();
            MessageBox.Show("Сохранение успешно завершено.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            Models.LightClass.main.gridM.Children.Clear();
            Models.LightClass.main.gridM.Children.Add(new ProductForm());
        }

        private void clImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (open.ShowDialog() == true)
            {
                imgPerson.Source = new BitmapImage(new Uri(open.FileName));
                selectedProduct.photo= open.FileName.Split('\\').LastOrDefault();
            }
        }

        private void cl_Back(object sender, RoutedEventArgs e)
        {
            Models.LightClass.main.gridM.Children.Clear();
            Models.LightClass.main.gridM.Children.Add(new ProductForm());
        }

        private void cbEnergy_DropDownOpened(object sender, EventArgs e)
        {
            cbEnergy.Foreground = Brushes.Black;
        }

        private void cbEnergy_DropDownClosed(object sender, EventArgs e)
        {
            cbEnergy.Foreground = Brushes.White;
        }
    }
}

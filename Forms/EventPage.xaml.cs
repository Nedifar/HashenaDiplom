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
    /// Логика взаимодействия для EventPage.xaml
    /// </summary>
    public partial class EventPage : UserControl
    {
        public int _id = 0;
        public EventPage(int id)
        {
            InitializeComponent();
            _id = id;
            ids ids = new ids{ id = id };
            DataContext = ids;
            if (_id != 0)
            { 
                var list = Models.context.AgetDB().Ads.Where(p => p.idDepartament == _id).ToList();
                var newList = new List<Models.Ad>();
                foreach(var item in list)
                {
                    if (item.isActive)
                        newList.Add(item);
                }
                dgOrder.ItemsSource = newList;
            }
            else
                dgOrder.ItemsSource = Models.context.AgetDB().Ads.ToList();

        }
        class ids
        {
            public int id { get; set; }
        }

        private void clEdit(object sender, RoutedEventArgs e)
        {
            var sens = (sender as Button).DataContext as Models.Ad;
            Models.LightClass.main.gridM.Children.Clear();
            Models.LightClass.main.gridM.Children.Add(new AddAd(sens));
        }

        private void clDelete(object sender, RoutedEventArgs e)
        {
            if(dgOrder.SelectedItems.Count!=1)
            { MessageBox.Show("Выберите 1 элемент для удаления.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information); }
            else
            {
                var sens = dgOrder.SelectedItem as Models.Ad;
                Models.context.AgetDB().Ads.Remove(sens);
                MessageBox.Show("Успешно удалено.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (_id != 0)
            {
                var list = Models.context.AgetDB().Ads.Where(p => p.idDepartament == _id).ToList();
                var newList = new List<Models.Ad>();
                foreach (var item in list)
                {
                    if (item.isActive)
                        newList.Add(item);
                }
                dgOrder.ItemsSource = newList;
            }
            else
                dgOrder.ItemsSource = Models.context.AgetDB().Ads.ToList();
        }

        private void clAdd(object sender, RoutedEventArgs e)
        {
            Models.LightClass.main.gridM.Children.Clear();
            Models.LightClass.main.gridM.Children.Add(new AddAd(null));
        }
    }
}

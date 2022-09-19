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
    /// Логика взаимодействия для AddAd.xaml
    /// </summary>
    public partial class AddAd : UserControl
    {
        Models.Ad ad = new Models.Ad();
        public AddAd(Models.Ad _ad)
        {
            InitializeComponent();
            if (_ad != null)
            {
                ad = _ad;
                datePicker.SelectedDate = ad.date;
                timePicker.SelectedTime = ad.date;
            }
            DataContext = ad;
            cb.ItemsSource = Models.context.AgetDB().Departaments.ToList();
        }

        private void clSave(object sender, RoutedEventArgs e)
        {
            ad.date = datePicker.SelectedDate.Value.AddHours(timePicker.SelectedTime.Value.Hour).AddMinutes(timePicker.SelectedTime.Value.Minute);
            if (ad.idAd == 0)
                Models.context.AgetDB().Ads.Add(ad);
            Models.context.AgetDB().SaveChanges();
            MessageBox.Show("Успешно опубликовано.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            Models.LightClass.main.gridM.Children.Clear();
            if(Models.LightClass.main.btEveAdmin.Visibility==Visibility.Visible)
            Models.LightClass.main.gridM.Children.Add(new EventPage(0));
            else
                Models.LightClass.main.gridM.Children.Add(new EventPage(Models.LightClass.main.prEmployee.idDepartament));

        }

        private void cl_Back(object sender, RoutedEventArgs e)
        {
            Models.LightClass.main.gridM.Children.Clear();
            if (Models.LightClass.main.btEveAdmin.Visibility == Visibility.Visible)
                Models.LightClass.main.gridM.Children.Add(new EventPage(0));
            else
                Models.LightClass.main.gridM.Children.Add(new EventPage(Models.LightClass.main.prEmployee.idDepartament));
        }

        private void cb_DropDownOpened(object sender, EventArgs e)
        {
            cb.Foreground = Brushes.Black;

        }

        private void cb_DropDownClosed(object sender, EventArgs e)
        {
            cb.Foreground = Brushes.White;

        }

        private void datePicker_CalendarOpened(object sender, RoutedEventArgs e)
        {
            datePicker.Foreground = Brushes.Black;

        }

        private void datePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            datePicker.Foreground = Brushes.White;

        }
    }
}

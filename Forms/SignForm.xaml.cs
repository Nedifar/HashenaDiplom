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
using System.Windows.Shapes;

namespace Project.Forms
{
    /// <summary>
    /// Логика взаимодействия для SignForm.xaml
    /// </summary>
    public partial class SignForm : Window
    {
        public SignForm()
        {
            InitializeComponent();
            var deps = Models.context.AgetDB().Departaments.ToList();
            deps.Insert(0,new Models.Departament { name = "Клиент" });
            var c = Models.context.AgetDB().Buyers.ToList();
            cbRole.ItemsSource = deps;
        }
        private void toSign(object sender, RoutedEventArgs e)
        {
            var model = cbRole.SelectedItem as Models.Departament;
            var user = Models.context.AgetDB().Employees.Where(p => p.login == login.Text && p.password == password.Password && p.Departament.idDepartament == model.idDepartament).FirstOrDefault();
            var admin = Models.context.AgetDB().Administrators.Where(p => p.Login == login.Text && p.Password == password.Password).FirstOrDefault();
            var buy = Models.context.AgetDB().Buyers.Where(p => p.login == login.Text && p.pas == password.Password).FirstOrDefault();
            if (user != null)
            {
                Models.context.AgetDB().Histories.Add(new Models.History { Attempt = "Успех", dateSign = DateTime.Now.ToString("dd.MM.yyyy HH.mm"), Login = login.Text });
                Models.context.AgetDB().SaveChanges();
                MessageBox.Show("Вход выполнен успешно.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                var mn = new Main(user, "");
                mn.Show();
                Models.LightClass.main = mn;
                Models.LightClass.Employee = user;
                Close();
            }
            else if (admin != null)
            {
                MessageBox.Show("Вход выполнен успешно.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                var mn = new Main(null, "");
                mn.Show();
                Models.LightClass.main = mn;
                Close();
            }
            else if(buy != null)
            {
                MessageBox.Show("Вход выполнен успешно.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                var mn = new Main(null, "buy");
                Models.LightClass.buyer = buy;
                mn.Show();
                Models.LightClass.main = mn;
                Close();
            }
            else
            {
                Models.context.AgetDB().Histories.Add(new Models.History { Attempt = "Провал", dateSign = DateTime.Now.ToString("dd.MM.yyyy HH.mm"), Login = login.Text });
                Models.context.AgetDB().SaveChanges();
                MessageBox.Show("Неправильный логин или пароль.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Click_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

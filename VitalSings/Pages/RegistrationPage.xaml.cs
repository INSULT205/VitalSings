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
using VitalSings.Models;

namespace VitalSings.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        private void RegistrationBT_Click_1(object sender, RoutedEventArgs e)
        {
            if (NameTB.Text == "" || LoginTB.Text == "" || PasswordPB.Password == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                User user = new User();
                user.Name = NameTB.Text;
                user.Login = LoginTB.Text;
                user.Password = PasswordPB.Password;
                bool loginExists = App.DB.User.Any(u => u.Login == user.Login);
                if (loginExists)
                {
                    MessageBox.Show("Логин уже используется. Выберите другой!");
                    return;
                }
                else 
                {
                    App.DB.User.Add(user);
                    App.DB.SaveChanges();
                    NavigationService.Navigate(new GenderPage(user));
                }
            }

        }

        private void BackTB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}

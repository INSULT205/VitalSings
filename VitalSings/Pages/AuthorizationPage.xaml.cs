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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VitalSings.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
            if (Properties.Settings.Default.RememberMe)
            {
                LoginTb.Text = Properties.Settings.Default.Login;
                PasswordPb.Password = Properties.Settings.Default.Password;
                CheckBoxRememberMe.IsChecked = Properties.Settings.Default.RememberMe;
            }
        }

        private void LoginBT_Click(object sender, RoutedEventArgs e)
        {
            var user = App.DB.User.FirstOrDefault(u => (u.Login == LoginTb.Text) && u.Password == PasswordPb.Password);
            if (user == null)
            {
                MessageBox.Show("Неправильный логин или пароль");
                return;
            }
            NavigationService.Navigate(new MajorPage(user));
            if (CheckBoxRememberMe.IsChecked.Value)
            {
                Properties.Settings.Default.RememberMe = true;
                Properties.Settings.Default.Login = LoginTb.Text;
                Properties.Settings.Default.Password = PasswordPb.Password;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.RememberMe = false;
                Properties.Settings.Default.Login = string.Empty;
                Properties.Settings.Default.Password = string.Empty;
                Properties.Settings.Default.Save();
            }
        }

        private void RegistrationTB_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}

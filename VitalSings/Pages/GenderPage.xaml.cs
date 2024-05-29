using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для GenderPage.xaml
    /// </summary>
    public partial class GenderPage : Page
    {
        User contextUser;
        public GenderPage(User user)
        {
            InitializeComponent();
            contextUser = user;
            GenderLV.ItemsSource = App.DB.Gender.ToList();
        }

        private void NextBt_Click(object sender, RoutedEventArgs e)
        {
            var GenderItem = GenderLV.SelectedItem as Gender;
            if (GenderItem == null)
            {
                MessageBox.Show("Вы не выбрали свой пол");
            }
            else
            {
                contextUser.GenderId = GenderItem.Id;
                App.DB.SaveChanges();
                NavigationService.Navigate(new LifeStylePage(contextUser));
            }
            
        }
    }
}

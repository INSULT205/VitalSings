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
    /// Логика взаимодействия для LifeStylePage.xaml
    /// </summary>
    public partial class LifeStylePage : Page
    {
        User contextUser;
        public LifeStylePage(User user)
        {
            InitializeComponent();
            contextUser = user;
            LifeStyleLV.ItemsSource = App.DB.Lifestyle.ToList();
        }

        private void NextBt_Click(object sender, RoutedEventArgs e)
        {
            var LifeStyleItem = LifeStyleLV.SelectedItem as Lifestyle;
            if (LifeStyleItem == null)
            {
                MessageBox.Show("Вы не выбрали свой образ жизни");
            }
            else
            {
                contextUser.LifestyleId = LifeStyleItem.Id;
                App.DB.SaveChanges();
                NavigationService.Navigate(new CharacterizationPage(contextUser));
            }
            
        }
    }
}

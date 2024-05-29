using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VitalSings.Models;

namespace VitalSings.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        User contextUser;
        List<Gender> genders { get; set; }
        List<Lifestyle> lifestyles { get; set; }
        List<Purpose> purposes { get; set; }
       
        public ProfilePage(User user)
        {
            InitializeComponent();
            contextUser = user;
            Refresh();
            this.DataContext = this;        
   
        }

        public void Refresh()
        {
            NameTB.Text = contextUser.Name.ToString();
            HeightTB.Text = contextUser.Height.ToString();
            MassTB.Text = contextUser.Mass.ToString();
            AgeTB.Text = contextUser.Age.ToString();

            genders = App.DB.Gender.ToList();
            GenderCB.ItemsSource = genders;
            GenderCB.SelectedIndex = (int)(contextUser.GenderId - 1);

            lifestyles = App.DB.Lifestyle.ToList();
            LifeStyleCB.ItemsSource = lifestyles;
            LifeStyleCB.SelectedIndex = (int)(contextUser.LifestyleId - 1);

            purposes = App.DB.Purpose.ToList();
            PurposeCB.ItemsSource = purposes;
            PurposeCB.SelectedIndex = (int)(contextUser.PurposeId - 1);
        }

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            contextUser.Name = NameTB.Text;
            contextUser.Height = int.Parse(HeightTB.Text);
            contextUser.Mass = double.Parse(MassTB.Text);
            contextUser.Age = int.Parse(AgeTB.Text);
            var g = GenderCB.SelectedItem as Gender;
            contextUser.GenderId = g.Id;
            var l = LifeStyleCB.SelectedItem as Lifestyle;
            contextUser.LifestyleId = l.Id;
            var p = PurposeCB.SelectedItem as Purpose;
            contextUser.PurposeId = p.Id;
            App.DB.SaveChanges();
            MessageBox.Show("Ваши изменения успешно применены!");
        }

        private void CountTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]");
            if (!regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
        private void MainTB_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MajorPage(contextUser));
        }

        private void StatisticTB_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new StatisticPage(contextUser));
        }

        private void ExitBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}

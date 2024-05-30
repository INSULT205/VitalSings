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
            
            if(NameTB.Text =="")
            {
                MessageBox.Show("Заполните поле имени");
            }
            else if (int.Parse(HeightTB.Text) < 100)
            {
                MessageBox.Show("Ваш рост не может быть меньше 100 см");
                return;
            }
            else if (int.Parse(HeightTB.Text) > 280)
            {
                MessageBox.Show("Ваш рост не может быть больше 280 см");
                return;
            }
            else if (double.Parse(MassTB.Text) < 10)
            {
                MessageBox.Show("Ваш вес не может быть меньше 10 кг");
                return;
            }

            else if (double.Parse(MassTB.Text) > 400)
            {
                MessageBox.Show("Ваш вес не может быть больше 400 кг");
                return;
            }
            else if (int.Parse(AgeTB.Text) < 0)
            {
                MessageBox.Show("Ваш возраст не может быть меньше 0 лет");
                return;
            }

            else if (int.Parse(AgeTB.Text) > 130)
            {
                MessageBox.Show("Ваш возраст не может быть больше 130 лет");
                return;
            }
            else
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
        private void MassTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!Regex.IsMatch(textBox.Text, @"^\d*(,\d*)?$"))
            {
                textBox.Text = Regex.Replace(textBox.Text, @"[^0-9,]", "");
                textBox.CaretIndex = textBox.Text.Length;
            }
            Refresh();
        }

        private void MassTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            Regex regex = new Regex("[0-9,]");
            if (!regex.IsMatch(e.Text))
            {
                e.Handled = true;
                return;
            }

            if (e.Text == "," && textBox.Text.Contains(","))
            {
                e.Handled = true;
                return;
            }

            if (e.Text == "," && textBox.Text.Length == 0)
            {
                e.Handled = true;
                return;
            }

            if (e.Text == "," && textBox.Text.Length == 1)
            {
                e.Handled = true;
                return;
            }

            if (e.Text == "," && textBox.SelectionStart > 0 && textBox.Text[textBox.SelectionStart - 1] == ',')
            {
                e.Handled = true;
                return;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для CharacterizationPage.xaml
    /// </summary>
    public partial class CharacterizationPage : Page
    {

        User contextUser;
        public static List<Purpose> purposes { get; set; }
        public CharacterizationPage(User user)
        {
            InitializeComponent();
            contextUser = user;
            PurposeCB.ItemsSource = App.DB.Purpose.ToList();
            Refresh();
        }

        private void CountTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]");
            if (!regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
       

        private void HeightPlusBT_Click(object sender, RoutedEventArgs e)
        {
            int height = int.Parse(HeightTB.Text);
            if(height > 280)
            {
                MessageBox.Show("Рост не может быть больше 280");
            }
            else 
            {
                height += 1;
                HeightTB.Text = height.ToString();
                Refresh();
            } 
        }


        private void HeightMinusBT_Click(object sender, RoutedEventArgs e)
        {
            int height = int.Parse(HeightTB.Text);
            if (height == 100)
                MessageBox.Show("Ваш рост не может быть меньше 100");
            else
            {
                height -= 1;
                HeightTB.Text = height.ToString();
                Refresh();
            }
        }

        private void AgeMinusBT_Click(object sender, RoutedEventArgs e)
        {
            int age = int.Parse(AgeTB.Text);
            if (age == 0)
                MessageBox.Show("Ваш возраст не может быть меньше 0");
            else
            {
                age -= 1;
                AgeTB.Text = age.ToString();
                Refresh();
            }
        }

        private void AgePlusBT_Click(object sender, RoutedEventArgs e)
        {
            int age = int.Parse(AgeTB.Text);
            if (age == 130)
            {
                MessageBox.Show("Ваш возраст не может быть 130 лет");
            }
            else
            {
                age += 1;
                AgeTB.Text = age.ToString();
                Refresh();
            }
            
        }

        private void MassMinusBT_Click(object sender, RoutedEventArgs e)
        {
            double mass = Double.Parse(MassTB.Text);
            if (mass == 0)
                MessageBox.Show("Ваш вес не может быть меньше 0");
            else
            {
                mass -= 1;
                MassTB.Text = mass.ToString();
                Refresh();
            }
        }

        private void MassPlusBT_Click(object sender, RoutedEventArgs e)
        {
            Double mass = Double.Parse(MassTB.Text);
            if (mass == 500)
            {
                MessageBox.Show("Ваш вес не может быть 500 кг");
            }
            else
            {
                mass += 1;
                MassTB.Text = mass.ToString();
                Refresh();
            }
        }
        private void NextBT_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            if (contextUser.Height == null || contextUser.Age == null || contextUser.Mass == null || contextUser.PurposeId == null)
            {
                MessageBox.Show("Вы не заполнили все поля");
            }
            else
            {
                App.DB.SaveChanges();
                NavigationService.Navigate(new KBJYPage(contextUser));
            }
        }

        private void CountTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            if (HeightTB.Text == "")
                HeightTB.Text = "100";
            if (MassTB.Text == "")
                MassTB.Text = "40";
            if (AgeTB.Text == "")
                AgeTB.Text = "13";
            contextUser.Height = int.Parse(HeightTB.Text);
            contextUser.Mass = Convert.ToDouble(MassTB.Text);
            contextUser.Age = int.Parse(AgeTB.Text);
            var Purposes = PurposeCB.SelectedItem as Purpose;
            if (Purposes != null)
                contextUser.PurposeId = Purposes.Id;
        }
    }
}

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
                MessageBox.Show("Ваш возраст не может быть меньше 0 лет");
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
            if (mass == 10)
                MessageBox.Show("Ваш вес не может быть меньше 10");
            else
            {
                mass -= 0.5;
                MassTB.Text = mass.ToString();
                Refresh();
            }
        }

        private void MassPlusBT_Click(object sender, RoutedEventArgs e)
        {
            Double mass = Double.Parse(MassTB.Text);
            if (mass == 400)
            {
                MessageBox.Show("Ваш вес не может быть 400 кг");
            }
            else
            {
                mass += 0.5;
                MassTB.Text = mass.ToString();
                Refresh();
            }
        }
        private void NextBT_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            if (contextUser.Height == null || contextUser.Age == null || contextUser.Mass == null)
            {
                MessageBox.Show("Вы не заполнили все поля");
            }
            else
            {
                if (contextUser.Height < 100)
                {
                    MessageBox.Show("Ваш рост не может быть меньше 100 см");
                    return;
                }
                else if (contextUser.Height > 280)
                {
                    MessageBox.Show("Ваш рост не может быть больше 280 см");
                    return;
                }
                else if (contextUser.Mass < 10)
                {
                    MessageBox.Show("Ваш вес не может быть меньше 10 кг");
                    return;
                }

                else if (contextUser.Mass > 400)
                {
                    MessageBox.Show("Ваш вес не может быть больше 400 кг");
                    return;
                }
                else if (contextUser.Age < 0)
                {
                    MessageBox.Show("Ваш возраст не может быть меньше 0 лет");
                    return;
                }

                else if (contextUser.Age > 130)
                {
                    MessageBox.Show("Ваш возраст не может быть больше 130 лет");
                    return;
                }
                else
                {
                    App.DB.SaveChanges();
                    NavigationService.Navigate(new KBJYPage(contextUser));
                }
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

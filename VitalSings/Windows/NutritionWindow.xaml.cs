using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
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
using System.Windows.Shapes;
using VitalSings.Models;

namespace VitalSings.Windows
{
    /// <summary>
    /// Логика взаимодействия для NutritionWindow.xaml
    /// </summary>
    public partial class NutritionWindow : Window
    {
        User contextUser;
        Product contextProduct;
        int CountProduct;
        public NutritionWindow(User user, Product product)
        {
            InitializeComponent();
            QuantityNutritionTB.Text = "0";
            NameTB.Text = product.Name + ", " + product.Unit.Name;
            contextUser = user;
            contextProduct = product;
            this.DataContext = this;
        }

        private void PlusFifBT_Click(object sender, RoutedEventArgs e)
        {
            CountProduct += 50;
            Refresh();
        }

        private void PlusHanBT_Click(object sender, RoutedEventArgs e)
        {
            CountProduct += 100;
            Refresh();
        }

        private void PlusTwoBT_Click(object sender, RoutedEventArgs e)
        {
            CountProduct += 200;
            Refresh();
        }

        private void MinusHanBT_Click(object sender, RoutedEventArgs e)
        {
            if (CountProduct >= 100)
                CountProduct -= 100;
            Refresh();
        }

        private void MinusFifBT_Click(object sender, RoutedEventArgs e)
        {
            if (CountProduct > 0)
                CountProduct -= 50;
            Refresh();
        }

        private void MinusTwoBT_Click(object sender, RoutedEventArgs e)
        {
            if (CountProduct >= 200)
                CountProduct -= 200;
            Refresh();
        }

        public void Refresh()
        {
            QuantityNutritionTB.Text = CountProduct.ToString();
        }

        private void AddNutritionBT_Click(object sender, RoutedEventArgs e)
        {
            Nutrition nutrition = new Nutrition();
            nutrition.ProductId = contextProduct.Id;
            nutrition.UserId = contextUser.Id;
            nutrition.DateTime = DateTime.Now;
            nutrition.QuantityOfProduct = CountProduct;
            App.DB.Nutrition.Add(nutrition);
            App.DB.SaveChanges();
            MessageBox.Show("Вы перекусили, вы большой молодец!");
            Close();
        }
        private void CountTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]");
            if (!regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
        private void CountTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CountProduct > 0 || QuantityNutritionTB.Text == "")
                CountProduct = int.Parse(QuantityNutritionTB.Text);
            else
                CountProduct = 0;
            Refresh();

        }
    }
}

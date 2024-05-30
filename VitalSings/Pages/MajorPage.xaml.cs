using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using VitalSings.Windows;

namespace VitalSings.Pages
{
    /// <summary>
    /// Логика взаимодействия для MajorPage.xaml
    /// </summary>
    public partial class MajorPage : Page
    {
        public static List<Nutrition> nutritions { get; set; }

        string CaloriesPartName;
        string ProteinPartName;
        string FatsPartName;
        string CarboPartName;
        User contextUser;

        public MajorPage(User user)
        {
            InitializeComponent();
            contextUser = user;
            Refresh();
        }

        private void DrinkWaterBT_Click(object sender, RoutedEventArgs e)
        {
            WaterIntakeWindow waterIntakeWindow = new WaterIntakeWindow(contextUser);
            waterIntakeWindow.Show();
        }

        private void ProfileTB_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ProfilePage(contextUser));
        }

        private void NutritionBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductPage(contextUser));
        }

        public void Refresh()
        {
            nutritions = App.DB.Nutrition.Where(x => x.UserId == contextUser.Id && DbFunctions.TruncateTime(x.DateTime) == DbFunctions.TruncateTime(DateTime.Now)).ToList();

            double protein = 0;
            double fats = 0;
            double carbohydrates = 0;
            double calories = 0;

            for (int i = 0; i < nutritions.Count; i++)
            {
                protein += nutritions[i].Product.Protein.Value / 100 * nutritions[i].QuantityOfProduct.Value;
                fats += nutritions[i].Product.Fats.Value / 100 * nutritions[i].QuantityOfProduct.Value;
                carbohydrates += nutritions[i].Product.Carbohydrates.Value / 100 * nutritions[i].QuantityOfProduct.Value;
                calories += (double)nutritions[i].Product.Calories.Value / 100 * nutritions[i].QuantityOfProduct.Value;
            }

            CaloriesPartName = Math.Round(calories,2).ToString();
            ProteinPartName = Math.Round(protein,2).ToString();
            FatsPartName = Math.Round(fats,2).ToString();
            CarboPartName = Math.Round(carbohydrates, 2).ToString();

            ProteinPB.Value = protein;
            FatsPB.Value = fats;
            CarbohydratesPB.Value = carbohydrates;
            ProteinPB.Maximum = Math.Round(contextUser.Protein, 2);
            FatsPB.Maximum = Math.Round(contextUser.Fats, 2);
            CarbohydratesPB.Maximum = Math.Round(contextUser.Carbohydrates, 2);

            string Cal = (Math.Round(contextUser.KBJY,2)).ToString();
            string Prot = (Math.Round(contextUser.Protein, 2)).ToString();
            string Fat = (Math.Round(contextUser.Fats, 2)).ToString();
            string Carbo = (Math.Round(contextUser.Carbohydrates, 2)).ToString();

            ProteinTB.Text = ProteinPartName + " / " + Prot;
            FatsTB.Text = FatsPartName + " / " + Fat;
            CarbohydratesTB.Text = CarboPartName + " / " + Carbo;
            CalloriesTB.Text = CaloriesPartName + " / " + Cal;

            double ElipseColorIndicator = Convert.ToDouble(calories) / Convert.ToDouble(Cal);
            if (ElipseColorIndicator > 1)
                ElipseColorIndicator = 100;
            double value = ElipseColorIndicator;
            GradientStopCollection gradientStops = ((LinearGradientBrush)EllipseKal.Fill).GradientStops;
            gradientStops[1].Offset = value;


            NutritionLV.ItemsSource = nutritions;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var nutrition = (sender as TextBlock).DataContext as Nutrition;
            App.DB.Nutrition.Remove(nutrition);
            App.DB.SaveChanges();
            Refresh();
        }

        private void StatisticsTB_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new StatisticPage(contextUser));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}


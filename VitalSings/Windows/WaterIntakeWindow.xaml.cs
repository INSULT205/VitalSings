using System;
using System.Collections.Generic;
using System.Data.Common;
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
using System.Windows.Shapes;
using VitalSings.Models;

namespace VitalSings.Windows
{
    /// <summary>
    /// Логика взаимодействия для WaterIntakeWindow.xaml
    /// </summary>
    public partial class WaterIntakeWindow : Window
    {
        public static List<User> users { get; set; }
        User contextUser;
        int CountWater;
        public WaterIntakeWindow(User user)
        {
            InitializeComponent();
            QuantityWaterTB.Text = "0";
            contextUser = user;
            this.DataContext = this;

        }

        private void PlusFifBT_Click(object sender, RoutedEventArgs e)
        {
            CountWater += 50;
            Refresh();
        }

        private void PlusHanBT_Click(object sender, RoutedEventArgs e)
        {
            CountWater += 100;
            Refresh();
        }

        private void PlusTwoBT_Click(object sender, RoutedEventArgs e)
        {
            CountWater += 200;
            Refresh();
        }

        private void MinusFifBT_Click(object sender, RoutedEventArgs e)
        {
            if (CountWater > 0)
                CountWater -= 50;
            Refresh();
        }

        private void MinusHanBT_Click(object sender, RoutedEventArgs e)
        {
            if (CountWater >= 100)
                CountWater -= 100;
            Refresh();
        }

        private void MinusTwoBT_Click(object sender, RoutedEventArgs e)
        {
            if (CountWater >= 200)
                CountWater -= 200;
            Refresh();
        }

        private void Refresh()
        {
            QuantityWaterTB.Text = CountWater.ToString();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WaterIntake waterIntake = new WaterIntake();
            waterIntake.QuantityOfWater = CountWater;
            waterIntake.IntakeDate = DateTime.Now;
            waterIntake.UserId = contextUser.Id;
            App.DB.WaterIntake.Add(waterIntake);
            App.DB.SaveChanges();
            MessageBox.Show("Вы выпили воду, вы большой умничка!");
            Close();
        }
    }
}

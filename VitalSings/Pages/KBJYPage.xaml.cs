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
    /// Логика взаимодействия для KBJYPage.xaml
    /// </summary>
    public partial class KBJYPage : Page
    {
        User contextUser;
        public KBJYPage(User user)
        {
            InitializeComponent();
            contextUser = user;
            CaloriesTB.Text = (Math.Round(contextUser.KBJY, 2)).ToString();
            ProteinTB.Text = (Math.Round(contextUser.Protein, 2)).ToString();
            FatsTB.Text = (Math.Round(contextUser.Fats, 2)).ToString();
            CarbohydratesTB.Text = (Math.Round(contextUser.Carbohydrates, 2)).ToString();
        }

        private void NextBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MajorPage(contextUser));
        }
    }
}

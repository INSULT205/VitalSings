using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Security.RightsManagement;
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

namespace VitalSings.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        List<Category> categories { get; set; }
        List<Unit> units { get; set; }
        Product Product;
        public AddProductWindow()
        {
            InitializeComponent();
            Product product = new Product();
            Product = product;
            categories = App.DB.Category.ToList();
            CategoryCB.ItemsSource = categories;
            

            units = App.DB.Unit.ToList();
            UnitCB.ItemsSource = units;
        }

        public void Refresh()
        {
            Product.Name = NameTB.Text;
            Product.Calories = int.Parse(CaloriesTB.Text);
            Product.Protein = Double.Parse(ProteinTB.Text);

            Product.Fats = Double.Parse(FatsTB.Text);
            Product.Carbohydrates = Double.Parse(CarbohydratesTB.Text);

            var units = UnitCB.SelectedItem as Unit;
            if (units != null)
                Product.UnitId = units.Id;

            var categories = CategoryCB.SelectedItem as Category;
            if (categories != null)
                Product.CategoryId = categories.Id;
        }

        private void AddProductBT_Click(object sender, RoutedEventArgs e)
        {
            if (NameTB.Text == null || CaloriesTB.Text == null || ProteinTB.Text == null || FatsTB.Text == null || CarbohydratesTB.Text == null ||
                CategoryCB.ItemsSource == null || UnitCB.ItemsSource == null)
            {
                MessageBox.Show("Вы не заполнили все поля!!!");
            }
            else
            {
                double result;
                int resultInt;
                if (int.TryParse(CaloriesTB.Text, out resultInt) && double.TryParse(ProteinTB.Text, out result) && double.TryParse(FatsTB.Text, out result) && double.TryParse(CarbohydratesTB.Text, out result))
                {
                    Refresh();
                    App.DB.Product.Add(Product);
                    App.DB.SaveChanges();
                    MessageBox.Show("Вы успешно добавили новый продукт!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Строки имели неверный формат ввода");
                } 
            }
           
        }

        private void CaloriesTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

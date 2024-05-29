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
using System.Windows.Navigation;
using System.Windows.Shapes;
using VitalSings.Models;
using VitalSings.Windows;

namespace VitalSings.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        User contextUser;
        public List<Product> Products { get; set; }
        public static List<Category> Categories { get; set; }
        public ProductPage(User user)
        {
            InitializeComponent();
            contextUser = user;
            Products = App.DB.Product.ToList();
            Categories = App.DB.Category.ToList();
            ProductLV.ItemsSource = Products;
            CategoryCB.ItemsSource = Categories;
            Categories.Insert(0, new Category() { Name = "Все категории" });
            CategoryCB.SelectedIndex = 0;
            this.DataContext = this;
        }
        private void FilterTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void CategoryCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void ProductLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NutritionWindow nutritionWindow = new NutritionWindow(contextUser, ProductLV.SelectedItem as Product);
            nutritionWindow.Show();
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MajorPage(contextUser));
        }

        private void AddProductBT_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var product = (sender as TextBlock).DataContext as Product;
            App.DB.Product.Remove(product);
            App.DB.SaveChanges();
            Refresh();
        }
        private void Refresh()
        {
            var filterProduct = App.DB.Product.ToList();
            if (FilterTB.Text.Length > 0)
            {
                filterProduct = filterProduct.Where(i => i.Name.ToLower().StartsWith(FilterTB.Text.Trim().ToLower())).ToList();
            }

            var name = CategoryCB.SelectedItem as Category;
            if (CategoryCB.SelectedIndex > 0 && name != null)
                filterProduct = filterProduct.Where(x => x.CategoryId == name.Id).ToList();

            ProductLV.ItemsSource = filterProduct;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void RefreshBT_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}

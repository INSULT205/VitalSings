using LiveCharts.Wpf;
using LiveCharts;
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
using System.Data.Entity;
using LiveCharts.Wpf.Charts.Base;
using LiveCharts.Definitions.Charts;
using System.Security.RightsManagement;

namespace VitalSings.Pages
{
    /// <summary>
    /// Логика взаимодействия для StatisticPage.xaml
    /// </summary>
    public partial class StatisticPage : Page
    {
        private List<Product> products;
        private List<Nutrition> nutritions;
        private List<WaterIntake> waterIntakes;
        User contextUser;

        public StatisticPage(User user)
        {
            InitializeComponent();
            contextUser = user;
            LoadData();
            LoadNutritionsChart();
            LoadWaterChart();
        }


        private void LoadData()
        {
            products = App.DB.Product.ToList();
            nutritions = App.DB.Nutrition.Where(x => x.UserId == contextUser.Id).ToList();
            waterIntakes = App.DB.WaterIntake.Where(x => x.UserId == contextUser.Id).ToList();
        }

        private void LoadNutritionsChart()
        {
            var oneWeekAgo = DateTime.Today.AddDays(-7);
            var chartDataList = nutritions
            .Where(n => (n.DateTime ?? DateTime.MinValue) >= oneWeekAgo)
            .GroupBy(n => (n.DateTime ?? DateTime.MinValue).Date)
            .Select(g => new ChartData
            {
                Date = g.Key,
                Calories = g.Sum(n => n.QuantityOfProduct / 100 * n.Product.Calories.Value ?? 0),
                Protein = g.Sum(n => n.QuantityOfProduct / 100 * n.Product.Protein.Value ?? 0),
                Fats = g.Sum(n => n.QuantityOfProduct / 100 * n.Product.Fats.Value ?? 0),
                Carbohydrates = g.Sum(n => n.QuantityOfProduct / 100 * n.Product.Carbohydrates.Value ?? 0)
            })
            .OrderBy(cd => cd.Date)
            .ToList();
            CreateNutritionsChart(chartDataList);
        }

        private void CreateNutritionsChart(List<ChartData> chartData)
        {
            nutritionsChart.Series.Clear();

            var caloriesSeries = new ColumnSeries
            {
                Title = "Калории",
                Values = new ChartValues<double>(chartData.Select(cd => cd.Calories))
            };
            var proteinSeries = new ColumnSeries
            {
                Title = "Белки",
                Values = new ChartValues<double>(chartData.Select(cd => cd.Protein))
            };
            var fatsSeries = new ColumnSeries
            {
                Title = "Жиры",
                Values = new ChartValues<double>(chartData.Select(cd => cd.Fats))
            };
            var carbohydratesSeries = new ColumnSeries
            {
                Title = "Углеводы",
                Values = new ChartValues<double>(chartData.Select(cd => cd.Carbohydrates))
            };

            nutritionsChart.Series = new SeriesCollection
            {
                caloriesSeries,
                proteinSeries,
                fatsSeries,
                carbohydratesSeries
            };
            nutritionsChart.AxisX.Clear();
            nutritionsChart.AxisX.Add(new Axis
            {
                Title = "Дата",
                Labels = chartData.Select(cd => cd.Date.ToString("dd.MM.yy")).ToList()
            });

            nutritionsChart.AxisY.Clear();
            nutritionsChart.AxisY.Add(new Axis
            {
                Title = "Количество",
                LabelFormatter = value => value.ToString("N")
            });
        }

        private void LoadWaterChart()
        {
            var oneWeekAgo = DateTime.Today.AddDays(-7);
            var waterChartDataList = waterIntakes
                .Where(w => w.IntakeDate >= oneWeekAgo)
                .GroupBy(w => (w.IntakeDate ?? DateTime.MinValue).Date)
                .Select(g => new WaterChartData
                {
                    Date = g.Key,
                    Water = g.Sum(w => w.QuantityOfWater ?? 0)
                })
                .OrderBy(wd => wd.Date)
                .ToList();

            CreateWaterChart(waterChartDataList);
        }
        private void CreateWaterChart(List<WaterChartData> waterChartData)
        {
            waterChart.Series.Clear();

            var waterSeries = new ColumnSeries
            {
                Title = "Количество выпитого",
                Values = new ChartValues<double>(waterChartData.Select(wd => wd.Water))
            };

            waterChart.Series = new SeriesCollection
            {
                waterSeries
            };

            waterChart.AxisX.Clear();
            waterChart.AxisX.Add(new Axis
            {
                Title = "Дата",
                Labels = waterChartData.Select(wd => wd.Date.ToString("dd.MM.yy")).ToList()
            });

            waterChart.AxisY.Clear();
            waterChart.AxisY.Add(new Axis
            {
                Title = "Миллилитры",
                LabelFormatter = value => value.ToString("N")
            });
        }

        private void ProfileTB_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ProfilePage(contextUser));
        }

        private void MainTB_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MajorPage(contextUser));
        }

        private void PrintNutritionsChart_Click(object sender, RoutedEventArgs e)
        {
            PrintChart(nutritionsChart, "График приема пищи");
        }
        private void PrintWaterChart_Click(object sender, RoutedEventArgs e)
        {
            PrintChart(waterChart, "График приема воды");
        }
        private void PrintChart(FrameworkElement chart, string description)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(chart, description);
            }
        }
    }

    public class ChartData
    {
        public DateTime Date { get; set; }
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
    }

    public class WaterChartData
    {
        public DateTime Date { get; set; }
        public double Water { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using VitalSings.Models;

namespace VitalSings
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static VitalSignsModelsEntities DB = new VitalSignsModelsEntities();
        public App()
        {
            Thread.Sleep(2000);
        }
    }
}

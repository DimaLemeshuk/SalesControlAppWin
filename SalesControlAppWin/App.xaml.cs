using PresentationLayer.Pages.LoginForm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SalesControlAppWin
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Створюємо екземпляр нового вікна
            var mainWindow = new Login(); // Замініть це на новий клас вікна, який ви хочете використовувати

            // Задаємо це вікно як головне вікно програми
            mainWindow.Show();
        }
    }
}

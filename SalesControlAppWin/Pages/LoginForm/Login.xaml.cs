using PresentationLayer.ViewModels.Control;
using SalesControlAppWin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace PresentationLayer.Pages.LoginForm
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBlock.Text;
            byte[] password = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(PasswordBox.Password));

            if (UserView.loginUser(UsernameTextBox.Text, MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(PasswordBox.Password))))
            {
                // Поточне вікно
                var currentWindow = Application.Current.MainWindow;

                // Створити нове вікно
                var newWindow = new MainWindow(); // Замініть на ваш клас нового вікна

                // Встановити нове вікно як головне вікно застосунку
                Application.Current.MainWindow = newWindow;

                // Закрити поточне вікно
                currentWindow.Close();

                // Відобразити нове вікно
                newWindow.Show();
            }
        }
    }
}

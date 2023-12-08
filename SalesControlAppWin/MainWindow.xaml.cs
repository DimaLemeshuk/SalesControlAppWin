using PresentationLayer.Pages;
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
using System.Windows.Threading;

namespace SalesControlAppWin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new Page1();
            //Page1Button.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x25, 0x6F, 0x46));

            var timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1); // Оновлювати кожну секунду
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Оновлення даних в текстових полях
            TimeTextBlock.Text = DateTime.Now.ToString("HH:mm");
            DateTextBlock.Text = DateTime.Now.ToString("dd.MM.yyyy");
        }

        private void Page1Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Page1();
        }

        private void Page2Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Page2();
        }

        private void Page3Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new testPage();
        }

        private void Page4Button_Click(object sender, RoutedEventArgs e)
        {
            //MainFrame.Content = new Page4();
        }

        private void Page5Button_Click(object sender, RoutedEventArgs e)
        {
            //MainFrame.Content = new Page5();

        }
    }
}



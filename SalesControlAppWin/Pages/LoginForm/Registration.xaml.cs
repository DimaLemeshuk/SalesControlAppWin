using PresentationLayer.ViewModels.Control;
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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var p1 = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(PasswordBox1.Password));
            var p2 = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(PasswordBox2.Password));

            UserView.NewUser(UsernameTextBox.Text, p1, p2, UserTypeComboBox.Text);
        }
    }
}

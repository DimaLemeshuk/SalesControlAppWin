
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services.Impl;
using DataAccessLayer.Repositoryes.Impl;
using PresentationLayer.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace PresentationLayer.Pages.Page2Frame
{
    /// <summary>
    /// Interaction logic for EnterprisesFrame.xaml
    /// </summary>
    public partial class CustomerFrame : Page
    {
        public CustomerFrame()
        {
            InitializeComponent();
        }

        private void FillButton_Click(object sender, RoutedEventArgs e)
        {
            CustomerView.AddNew(NameTextBox.Text, SurnameTextBox.Text, FathersnameTextBox.Text, PhonenumberTextBox.Text);
        }
    }
}

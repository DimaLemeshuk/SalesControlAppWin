
using PresentationLayer.ViewModels.Control;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PresentationLayer.Pages.Page2Frame
{
    /// <summary>
    /// Interaction logic for PollutionsFrame.xaml
    /// </summary>
    public partial class SupplierFrame : Page
    {
        public SupplierFrame()
        {
            InitializeComponent();
        }

        private void FillButton_Click(object sender, RoutedEventArgs e)
        {
            SupplierView.AddNew(NameSuppliersTextBox.Text, ContactsTextBox.Text, RatingTextBox.Text);
        }
    }
}

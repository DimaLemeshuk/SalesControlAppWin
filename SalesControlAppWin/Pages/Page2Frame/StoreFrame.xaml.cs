
using PresentationLayer.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PresentationLayer.Pages.Page2Frame
{
    /// <summary>
    /// Interaction logic for BelongingsFrame.xaml
    /// </summary>
    public partial class StoreFrame : Page
    {
        public StoreFrame()
        {
            InitializeComponent();
        }

        private void fillButton_Click(object sender, RoutedEventArgs e)
        {
            StoreView.AddNew(NameStoresTextBox.Text, ((ComboBoxItem)SocialNetvorcComboBox.SelectedItem).Content.ToString());
        }
    }
}

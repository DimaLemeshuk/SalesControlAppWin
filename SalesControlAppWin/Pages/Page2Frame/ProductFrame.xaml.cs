
using BusinessLogicLayer.Services.Impl;
using PresentationLayer.ViewModels;
using SaeediSoftWpfUiControls;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PresentationLayer.Pages.Page2Frame
{
    /// <summary>
    /// Interaction logic for PollutantsFrame.xaml
    /// </summary>
    public partial class ProductFrame : Page
    {
        public ProductFrame()
        {
            InitializeComponent();
        }


        private void FillBtton_Click(object sender, RoutedEventArgs e)
        {
             //var seletion = supplierComboBox.comboBoxControl.SelectedItem as SearchModel;
            //string s5 = seletion.DisplayField;


            ProductView.AddNew(NameTextBox.Text, descriptionTextBox.Text, priceTextBox.Text, quantityTextBox.Text, supplierComboBox.comboBoxControl.Text, groupComboBox.comboBoxControl.Text);
        }

        private void groupComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var groupproductService = new GroupproductService();
            var items = groupproductService.GetAll().ToList();
            
            // Конвертувати дані до ObservableCollection<SaeediSoftWpfUiControls.SearchModel>
            var observableCollection = new ObservableCollection<SaeediSoftWpfUiControls.SearchModel>(
                items.Select(dto => new SaeediSoftWpfUiControls.SearchModel
                {
                    // Перетворення значень на SearchModel
                    DisplayField = dto.NameGroupproducts,
                    StringFeild1 = dto.NameGroupproducts

                })
            );

            // Встановити отриману ObservableCollection як ItemsSource для ComboBox
            groupComboBox.ItemsSource = observableCollection;
            //var s = groupComboBox.DisplayMemberPath;
        }

        private void supplierComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var supplierService = new SupplierService();
            var items = supplierService.GetAll().ToList();

            // Конвертувати дані до ObservableCollection<SaeediSoftWpfUiControls.SearchModel>
            var observableCollection = new ObservableCollection<SaeediSoftWpfUiControls.SearchModel>(
                items.Select(dto => new SaeediSoftWpfUiControls.SearchModel
                {
                    // Перетворення значень на SearchModel
                    DisplayField = dto.NameSuppliers,
                    StringFeild1 = dto.NameSuppliers

                })
            );

            // Встановити отриману ObservableCollection як ItemsSource для ComboBox
            supplierComboBox.ItemsSource = observableCollection;
            //var s = supplierComboBox.DisplayMemberPath;
        }
    }
}

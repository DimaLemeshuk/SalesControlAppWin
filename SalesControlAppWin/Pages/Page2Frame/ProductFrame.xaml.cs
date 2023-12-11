
using BusinessLogicLayer.Services.Impl;
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

        }

        private void groupComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var groupproductService = new GroupproductService();
            var items = groupproductService.GetAll().ToList();
            
            // Конвертувати дані до ObservableCollection<SaeediSoftWpfUiControls.SearchModel>
            var observableCollection = new ObservableCollection<SaeediSoftWpfUiControls.SearchModel>(
                items.Select(dto => new SaeediSoftWpfUiControls.SearchModel
                {
                    // Перетворення значень з ProductDTO на SearchModel
                    // Наприклад:
                    DisplayField = dto.NameGroupproducts,
                    StringFeild1 = dto.NameGroupproducts
                    // Інші поля з ProductDTO...
                })
            );

            // Встановити отриману ObservableCollection як ItemsSource для ComboBox
            groupComboBox.ItemsSource = observableCollection;
            var s = groupComboBox.DisplayMemberPath;
        }
    }
}

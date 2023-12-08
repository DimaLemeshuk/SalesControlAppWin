using BusinessLogicLayer.Services.Impl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PresentationLayer.Pages
{
    /// <summary>
    /// Interaction logic for testPage.xaml
    /// </summary>
    public partial class testPage : Page
    {
        public testPage()
        {
            InitializeComponent();
            //uc_cbox.SelectionChanged += uc_cbox_SelectionChanged;
        }

        private void uc_cbox_Loaded(object sender, RoutedEventArgs e)
        {
            // Отримати дані з ProductService
            var productService = new ProductService();
            var items = productService.GetAll().ToList();

            // Конвертувати дані до ObservableCollection<SaeediSoftWpfUiControls.SearchModel>
            var observableCollection = new ObservableCollection<SaeediSoftWpfUiControls.SearchModel>(
                items.Select(dto => new SaeediSoftWpfUiControls.SearchModel
                {
                    // Перетворення значень з ProductDTO на SearchModel
                    // Наприклад:
                    DisplayField = dto.NameProducts,
                    StringFeild1 = dto.NameProducts
                    // Інші поля з ProductDTO...
                })
            );

            // Встановити отриману ObservableCollection як ItemsSource для ComboBox
            uc_cbox.ItemsSource = observableCollection;
            var s = uc_cbox.DisplayMemberPath;

        }

    }
}

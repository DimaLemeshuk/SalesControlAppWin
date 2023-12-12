using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services.Impl;
using PresentationLayer.Control;
using PresentationLayer.ViewModels;
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

namespace PresentationLayer.Pages
{
    /// <summary>
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        private object selectedRowDataGrid1;
        private object selectedRowDataGrid2;
        public Page3()
        {
            InitializeComponent();
            ProductView.PrintToDataGrid(DBGrid1);
            CustomerView.PrintToDataGrid(DBGrid2);
            StoreComboBox.ItemsSource = new StoreService().GetAll().Select(store => store.NameStores).ToList();
        }

        private void FindTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            DBGridControl.findInDataGrid(FindTextBox1.Text, DBGrid1);
        }

        private void FindTextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            DBGridControl.findInDataGrid(FindTextBox2.Text, DBGrid2);
        }

        private void FillBtton_Click(object sender, RoutedEventArgs e)
        {
            SaleView.AddNew(selectedRowDataGrid1, selectedRowDataGrid2, StoreComboBox.Text, QuantityTextBox.Text, AddressTextBox.Text, PaymentComboBox.Text);
        }

        private void DBGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DBGrid1.SelectedItem != null)
            {
                selectedRowDataGrid1 = DBGrid1.SelectedItem; 
                if(DBGrid1.SelectedItem is ProductDTO product)
                {
                    ProductTextBlock.Text = "Товар: " + product.NameProducts;
                    SetPrice();
                }
            }
        }

        private void DBGrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (DBGrid2.SelectedItem != null)
            {
                selectedRowDataGrid1 = DBGrid1.SelectedItem;
                if (DBGrid2.SelectedItem is CustomerDTO customer)
                {
                    CustomerTextBlock.Text = "Покупець: " + customer.Name + " " + customer.Surname ; 
                }
            }

        }

        private void SetPrice()
        {
            SaleAmountTextBlock.Text = "Вартість покупки:  " + SaleView.GetPrice(selectedRowDataGrid1, QuantityTextBox.Text);
        }

        private void QuantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetPrice();
        }
    }
}
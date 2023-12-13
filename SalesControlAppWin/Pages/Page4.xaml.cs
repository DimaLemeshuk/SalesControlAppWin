using BusinessLogicLayer.DTO;
using PresentationLayer.ViewModels;
using PresentationLayer.ViewModels.Control;
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
    /// Interaction logic for Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        private object selectedRowDataGrid1;
        public Page4()
        {
            InitializeComponent();
            ProductView.PrintToDataGrid(DBGrid1);
        }

        private void FillBtton_Click(object sender, RoutedEventArgs e)
        {
            DeliveryView.AddNew(selectedRowDataGrid1, (DateTime)dateTimePicker.Value, QuantityTextBox.Text, CostTextBox.Text);
        }

        private void SettData()
        {
            if(Double.TryParse(CostTextBox.Text.Replace('.', ','), out double fullPrice) && int.TryParse(QuantityTextBox.Text.Replace('.', ','), out int quantity) && selectedRowDataGrid1 is ProductDTO product)
            {
                ProfitTextBlock.Text = "Відсоток вигоди при поточній ціні: " + (product.Price - (fullPrice / quantity))/(product.Price / 100) + " %";
                ProductPriceTextBlock.Text = "Вартість одного товару: " + fullPrice/quantity;
            }
        }

        private void DBGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DBGrid1.SelectedItem != null)
            {
                selectedRowDataGrid1 = DBGrid1.SelectedItem;
                if (DBGrid1.SelectedItem is ProductDTO product)
                {
                    ProductTextBlock.Text = "Обрано товар: " + product.NameProducts;
                }
            }
            SettData();
        }

        private void QuantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SettData();
        }

        private void CostTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SettData();
        }
    }
}

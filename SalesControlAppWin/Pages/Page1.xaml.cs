
using PresentationLayer.Control;
using PresentationLayer.ViewModels;
using PresentationLayer.ViewModels.Control;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PresentationLayer.Pages
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            tableComboBox.SelectedIndex = 0;
            ProductView.PrintToDataGrid(DBGrid);
        }

        private void DBGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var editedItem = e.Row.Item;
            DBGridControl.updateRow(e, editedItem);
            //ProductView.PrintToDataGrid(DBGrid);

        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            if (DBGrid.SelectedItems != null)
            {
                foreach (var selectedItem in DBGrid.SelectedItems)
                {
                    DBGridControl.deleteRov(DBGrid, selectedItem);
                }

            }
            else
            {
                MessageBox.Show("Будь ласка, виділіть рядок, який ви хочете видалити.");
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            tableComboBox_SelectionChanged( sender,e as SelectionChangedEventArgs);
        }

        private void FindTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DBGridControl.findInDataGrid(FindTextBox.Text, DBGrid);

        }

        private void tableComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Отримати вибраний елемент ComboBox
            ComboBoxItem selectedTableItem = (ComboBoxItem)tableComboBox.SelectedItem;

            if (selectedTableItem != null)
            {
                // Отримати текст вибраного елемента (назву таблиці)
                string selectedTableName = selectedTableItem.Content.ToString();

                // Викликати відповідний метод print() для вибраної таблиці
                switch (selectedTableName)
                {
                    case "Товари":
                        ProductView.PrintToDataGrid(DBGrid);
                        break;
                    case "Продажі":
                        SaleView.PrintToDataGrid(DBGrid);
                        break;
                    case "Доставки":
                        DeliveryView.PrintToDataGrid(DBGrid);
                        break;
                    case "Постачальники":
                        SupplierView.PrintToDataGrid(DBGrid);
                        break;
                    case "Покупці":
                        CustomerView.PrintToDataGrid(DBGrid);
                        break;
                    case "Магазини":
                        StoreView.PrintToDataGrid(DBGrid);
                        break;
                    case "Користувачі":
                        UserView.PrintToDataGrid(DBGrid);
                        break;
                }
            }
        }
    }
}

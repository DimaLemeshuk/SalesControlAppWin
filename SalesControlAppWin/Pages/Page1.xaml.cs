
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

            SupplierView.PrintToDataGrid(DBGrid);
            //SaleView.PrintToDataGrid(DBGrid);
            //DeliveryView.PrintToDataGrid(DBGrid);
            //ProductView.PrintToDataGrid(DBGrid);

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
            ProductView.PrintToDataGrid(DBGrid);
        }

        private void FindTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DBGridControl.findInDataGrid(FindTextBox.Text, DBGrid);

        }
    }
}


using System.Linq;
using System.Windows;
using System.Windows.Controls;

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

            //ProductControl.PrintToDataGrid(DBGrid);

        }

        private void DBGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var editedItem = e.Row.Item;
            //DataControl.updateRow(e, editedItem);
            //ProductControl.PrintToDataGrid(DBGrid);

        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            if (DBGrid.SelectedItems != null)
            {
                foreach (var selectedItem in DBGrid.SelectedItems)
                {
                    //DataControl.deleteRov(DBGrid, selectedItem);
                }
                //ProductControl.PrintToDataGrid(DBGrid);

            }
            else
            {
                MessageBox.Show("Будь ласка, виділіть рядок, який ви хочете видалити.");
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            //ProductControl.PrintToDataGrid(DBGrid);
        }
    }
}

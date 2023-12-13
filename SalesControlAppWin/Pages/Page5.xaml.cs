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
    /// Interaction logic for Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        public Page5()
        {
            InitializeComponent();
            PrintInGrid();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SaleView.ChangeStatus(DBGrid1.SelectedItem, "Доставляється");//ENUM('Обробляється', 'Завершено', 'Доставляється', 'Повернено')
            PrintInGrid();
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            SaleView.ChangeStatus(DBGrid2.SelectedItem, "Повернено");
            PrintInGrid();
        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            SaleView.ChangeStatus(DBGrid2.SelectedItem, "Завершено");
            PrintInGrid();
        }

        private void PrintInGrid()
        {
            SaleView.PrintToDataGridOnlyNotSendOrSend(DBGrid1, "Обробляється");
            SaleView.PrintToDataGridOnlyNotSendOrSend(DBGrid2, "Доставляється");
        }

        private void DBGrid1_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var editedItem = e.Row.Item;
            DBGridControl.updateRow(e, editedItem);
        }
    }
}

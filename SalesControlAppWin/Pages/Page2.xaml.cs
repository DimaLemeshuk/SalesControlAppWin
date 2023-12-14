
using PresentationLayer.ViewModels.Control;
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
using PresentationLayer.Pages.Page2Frame;

namespace PresentationLayer.Pages
{
    /// <summary>
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            //MainFrame.Content = new EnterprisesFrame();
            //ChooseT.Text = EnterprisesTable.Content.ToString();
            tableComboBox.SelectedIndex = 0;
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
                        MainFrame.Content = new ProductFrame();
                        break;
                    //case "Продажі":
                    //    SaleView.PrintToDataGrid(DBGrid);
                    //    break;
                    //case "Доставки":
                    //    DeliveryView.PrintToDataGrid(DBGrid);
                    //    break;
                    case "Постачальники":
                        MainFrame.Content = new SupplierFrame();
                        break;
                    case "Покупці":
                        MainFrame.Content = new CustomerFrame();
                        break;
                    case "Магазини":
                        MainFrame.Content = new StoreFrame();
                        break;
                }
            }
        }
    }
}

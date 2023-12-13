using DataAccessLayer.Models;
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
    /// Interaction logic for Page6.xaml
    /// </summary>
    public partial class Page6 : Page
    {
        public Page6()
        {
            InitializeComponent();
            DeliveryView.PrintToDataGridOnlyNotSendOrSend(DBGrid1, "Заплановано");//ENUM('Заплановано', 'Доставлено', 'Відмінено')
        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeliveryView.ChangeStatus(DBGrid1.SelectedItem, "Доставлено");
            DeliveryView.PrintToDataGridOnlyNotSendOrSend(DBGrid1, "Заплановано");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DeliveryView.ChangeStatus(DBGrid1.SelectedItem, "Відмінено");
            DeliveryView.PrintToDataGridOnlyNotSendOrSend(DBGrid1, "Заплановано");
        }
    }
}

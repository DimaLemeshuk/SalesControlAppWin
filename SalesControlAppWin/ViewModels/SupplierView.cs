using BusinessLogicLayer.Services.Impl;
using PresentationLayer.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PresentationLayer.ViewModels.Control
{
    public class SupplierView
    {
        public static void PrintToDataGrid(DataGrid dataGrid)
        {
            DBGridControl.DelOllColumn(dataGrid);
            dataGrid.ItemsSource = new SupplierService().GetAll()
                .ToList();

            DBGridControl.AddColumn(dataGrid, "id", "Id", true);
            DBGridControl.AddColumn(dataGrid, "Назва", "NameSuppliers");
            DBGridControl.AddColumn(dataGrid, "Контакти", "Contacts");
            DBGridControl.AddColumn(dataGrid, "Рейтинг", "Rating");
        }
    }
}

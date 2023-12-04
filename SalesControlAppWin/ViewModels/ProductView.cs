using BusinessLogicLayer.Services.Impl;
using PresentationLayer.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PresentationLayer.ViewModels
{
    public class ProductView
    {
        public static void PrintToDataGrid(DataGrid dataGrid)
        {

            DBGridControl.DelOllColumn(dataGrid);
            dataGrid.ItemsSource = new ProductService().GetAll()
                .ToList();

            DBGridControl.AddColumn(dataGrid, "id", "Id", true);
            DBGridControl.AddColumn(dataGrid, "Назва", "NameProducts");
            DBGridControl.AddColumn(dataGrid, "Опис", "Description");
            DBGridControl.AddColumn(dataGrid, "Ціна", "Price");
            DBGridControl.AddColumn(dataGrid, "Доступна\nкількість", "AvailableQuantity");
            //DBGridControl.AddColumn(dataGrid, "Постачальник", "Suplier.NameSuppliers");
            //DBGridControl.AddColumn(dataGrid, "Категорія", "GroupProducts.NameGroupproducts");

        }
    }
}

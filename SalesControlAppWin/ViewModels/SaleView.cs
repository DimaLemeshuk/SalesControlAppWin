using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services.Impl;
using DataAccessLayer.Models;
using PresentationLayer.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PresentationLayer.ViewModels
{
    public class SaleView
    {
        public static void PrintToDataGrid(DataGrid dataGrid)
        {
            DBGridControl.DelOllColumn(dataGrid);
            dataGrid.ItemsSource = new SaleService().GetAll()
                .ToList();

            DBGridControl.AddColumn(dataGrid, "id", "Id", true);
            DBGridControl.AddColumn(dataGrid, "Товар", "ProductDTO.NameProducts", true);
            DBGridControl.AddColumn(dataGrid, "Назва магазину", "StoreDTO.NameStores", true);
            DBGridControl.AddColumn(dataGrid, "Дата та час здійснення\nзамовлення", "DateTime");
            DBGridControl.AddColumn(dataGrid, "Кількість", "Quantity");
            DBGridControl.AddColumn(dataGrid, "Загальна вартість", "SalesAmount");
            DBGridControl.AddColumn(dataGrid, "Статус", "Status");
            DBGridControl.AddColumn(dataGrid, "Ім'я замовника", "CustomersDTO.Name", true);
            DBGridControl.AddColumn(dataGrid, "Прізвище замовника", "CustomersDTO.Surname", true);

        }
    }
}

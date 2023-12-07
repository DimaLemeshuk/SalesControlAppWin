using BusinessLogicLayer.DTO;
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
    public class DeliveryView
    {
        public static void PrintToDataGrid(DataGrid dataGrid)
        {
            DBGridControl.DelOllColumn(dataGrid);
            dataGrid.ItemsSource = new DeliveryService().GetAll()
                .ToList();

            DBGridControl.AddColumn(dataGrid, "id", "Id", true);
            DBGridControl.AddColumn(dataGrid, "Товар", "ProductDTO.NameProducts", true);
            DBGridControl.AddColumn(dataGrid, "Дата доставки", "DateTime");
            DBGridControl.AddColumn(dataGrid, "Кількість", "Quantity");
            DBGridControl.AddColumn(dataGrid, "Загальна вартість", "DeliveryCost");
            DBGridControl.AddColumn(dataGrid, "Статус", "Status");
            DBGridControl.AddColumn(dataGrid, "Планована дата\nдоставки", "DateTime");
        }
    }
}

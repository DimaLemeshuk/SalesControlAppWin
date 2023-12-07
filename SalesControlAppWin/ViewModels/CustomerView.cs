using BusinessLogicLayer.Services.Impl;
using DataAccessLayer.Repositoryes.Impl;
using PresentationLayer.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PresentationLayer.ViewModels
{
    public class CustomerView
    {
        public static void PrintToDataGrid(DataGrid dataGrid)
        {
            DBGridControl.DelOllColumn(dataGrid);
            dataGrid.ItemsSource = new CustomerRepository().GetAll()
                .ToList();

            DBGridControl.AddColumn(dataGrid, "id", "Id", true);
            DBGridControl.AddColumn(dataGrid, "Ім'я", "Name");
            DBGridControl.AddColumn(dataGrid, "Прізвище", "Surname");
            DBGridControl.AddColumn(dataGrid, "По батькові", "Fathersname");
            DBGridControl.AddColumn(dataGrid, "Номер телефону", "Phonenumber");
        }
    }
}

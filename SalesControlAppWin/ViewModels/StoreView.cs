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
    public class StoreView
    {
        public static void PrintToDataGrid(DataGrid dataGrid)
        {
            DBGridControl.DelOllColumn(dataGrid);
            dataGrid.ItemsSource = new StoreRepository().GetAll()
                .ToList();

            DBGridControl.AddColumn(dataGrid, "id", "Id", true);
            DBGridControl.AddColumn(dataGrid, "Назва соцмережі", "SocialNetwork");
            DBGridControl.AddColumn(dataGrid, "Назва магазину", "NameStores");

        }
    }
}

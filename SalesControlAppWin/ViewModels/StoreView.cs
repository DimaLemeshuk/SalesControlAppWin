using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services.Impl;
using DataAccessLayer.Repositoryes.Impl;
using PresentationLayer.Control;
using System.Linq;
using System.Windows;
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

        public static void AddNew(string nameStores, string socialNetwork)
        {
            if (!(string.IsNullOrWhiteSpace(nameStores) || string.IsNullOrWhiteSpace(socialNetwork)))
            {
                try
                {
                    var storeService = new StoreService();
                    var store = new StoreDTO
                    {
                        NameStores = nameStores,
                        SocialNetwork = socialNetwork
                    };
                    if (storeService.Find(store => store.NameStores == nameStores && store.SocialNetwork == socialNetwork).FirstOrDefault() == null)
                    {
                        storeService.Create(store);
                        storeService.SaveChanges();
                        MessageBox.Show("Дані успішно додано!");
                    }
                    else
                    {
                        MessageBox.Show("Такий запис уже існує!");
                    }
                }
                catch
                {
                    MessageBox.Show("Введені невірні дані!");
                }
            }
            else
            {
                MessageBox.Show("Заповніть усі поля!");
            }
        }

    }

}

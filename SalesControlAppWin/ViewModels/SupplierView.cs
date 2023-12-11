using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services.Impl;
using DataAccessLayer.Models;
using PresentationLayer.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        public static void AddNew(string nameSuppliers, string contacts, string _rating)
        {
            if (!(string.IsNullOrWhiteSpace(nameSuppliers) || string.IsNullOrWhiteSpace(contacts) || string.IsNullOrWhiteSpace(_rating)))
            {
                if(Decimal.TryParse(_rating.Replace('.', ','), out decimal rating) && rating <= 5 && rating >= 0)
                {
                    try
                    {
                        var supplierService = new SupplierService();
                        var supplier = new SupplierDTO
                        {
                            NameSuppliers = nameSuppliers,
                            Contacts = contacts,
                            Rating = rating
                        };
                        if (supplierService.Find(supplier => supplier.NameSuppliers == nameSuppliers && supplier.Contacts == contacts).FirstOrDefault() == null)
                        {
                            supplierService.Create(supplier);
                            supplierService.SaveChanges();
                            MessageBox.Show("Дані успішно додано!");
                        }
                        else
                        {
                            MessageBox.Show("Такий запис уже існує!");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Сталася помилка! Перевірте введені дані.");
                    }
                }
                else
                {
                    MessageBox.Show("Рейтинг має бути числом ( або десятковими дробом).\nТакож дане число має бути в межах від 0 до 5.\nДе 5 - найвищий рейтинг");

                }
            }
            else
            {
                MessageBox.Show("Заповніть усі поля!");
            }
        }


    }
}

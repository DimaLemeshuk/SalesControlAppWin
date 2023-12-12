using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services.Impl;
using DataAccessLayer.Repositoryes.Impl;
using PresentationLayer.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PresentationLayer.ViewModels
{
    public class CustomerView
    {
        public static void PrintToDataGrid(DataGrid dataGrid)
        {
            DBGridControl.DelOllColumn(dataGrid);
            dataGrid.ItemsSource = new CustomerService().GetAll()
                .ToList();

            DBGridControl.AddColumn(dataGrid, "id", "Id", true);
            DBGridControl.AddColumn(dataGrid, "Ім'я", "Name");
            DBGridControl.AddColumn(dataGrid, "Прізвище", "Surname");
            DBGridControl.AddColumn(dataGrid, "По батькові", "Fathersname");
            DBGridControl.AddColumn(dataGrid, "Номер телефону", "Phonenumber");
        }

        public static void AddNew(string name, string surname, string fathersname, string phonenumber)
        {
            if (!(string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(fathersname) || string.IsNullOrWhiteSpace(phonenumber)))
            {
                try
                {
                    var customerService = new CustomerService();
                    var customer = new CustomerDTO
                    {
                        Name = name,
                        Surname = surname,
                        Fathersname = fathersname,
                        Phonenumber = phonenumber
                    };
                    if (customerService.Find(customer => customer.Name == name && customer.Phonenumber == phonenumber && customer.Surname == surname).FirstOrDefault() == null)
                    {
                        customerService.Create(customer);
                        customerService.SaveChanges();
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

using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services.Impl;
using PresentationLayer.Control;
using System;
using System.Linq;
using System.Windows;
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
            DBGridControl.AddColumn(dataGrid, "Адреса доставки", "Address");
            DBGridControl.AddColumn(dataGrid, "Спосіб доставки", "Payment");
            DBGridControl.AddColumn(dataGrid, "ТТН", "TTN");

        }

        public static void PrintToDataGridOnlyNotSendOrSend(DataGrid dataGrid, string send)
        {
            DBGridControl.DelOllColumn(dataGrid);
            dataGrid.ItemsSource = new SaleService().Find(s => s.Status.Equals(send))
                .ToList();

            DBGridControl.AddColumn(dataGrid, "id", "Id", true);
            DBGridControl.AddColumn(dataGrid, "Товар", "ProductDTO.NameProducts", true);
            DBGridControl.AddColumn(dataGrid, "Назва магазину", "StoreDTO.NameStores", true);
            DBGridControl.AddColumn(dataGrid, "Дата та час здійснення\nзамовлення", "DateTime", true);
            DBGridControl.AddColumn(dataGrid, "Кількість", "Quantity", true);
            DBGridControl.AddColumn(dataGrid, "Загальна вартість", "SalesAmount", true);      
            DBGridControl.AddColumn(dataGrid, "Ім'я замовника", "CustomersDTO.Name", true);
            DBGridControl.AddColumn(dataGrid, "Прізвище замовника", "CustomersDTO.Surname", true);
            DBGridControl.AddColumn(dataGrid, "Адреса доставки", "Address", true);
            DBGridControl.AddColumn(dataGrid, "Спосіб доставки", "Payment", true);
            DBGridControl.AddColumn(dataGrid, "ТТН", "TTN");
        }

        public static void ChangeStatus(object select, string newStatus)
        {
            if (select != null)
            {
                if (select is SaleDTO sale)
                {
                    var saleService = new SaleService();
                    saleService.Update(sale, "Status", newStatus);
                    saleService.SaveChanges();
                    MessageBox.Show("Статус змінено!");
                }
                else
                {
                    MessageBox.Show("Вибраний рядок некоректний!");
                }
            }
            else
            {
                MessageBox.Show("Рядок таблиці не вибрано!");
            }
        }


        public static void AddNew(object _product, object _customer, string nameStore, string _quantity, string address, string payment)
        {
            if (!(string.IsNullOrWhiteSpace(nameStore) || string.IsNullOrWhiteSpace(_quantity) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(payment)))
            {
                if (_product is ProductDTO product)
                {
                    if(_customer is CustomerDTO customer)
                    {
                        var storeService = new StoreService();
                        var store = storeService.Find(s => s.NameStores.Equals(nameStore)).FirstOrDefault();
                        if (store != null)
                        {
                            if (int.TryParse(_quantity.Replace('.', ','), out int quantity))
                            {
                                if(product.AvailableQuantity - quantity>=0)
                                {
                                    try
                                    {
                                        var saleService = new SaleService();
                                        var sale = new SaleDTO
                                        {
                                            ProductId = product.Id,
                                            StoreId = store.Id,
                                            DateTime = DateTime.Now,
                                            Quantity = quantity,
                                            Address = address,
                                            CustomersId = customer.Id,
                                            Payment = payment,
                                            Status = "Обробляється",
                                            SalesAmount = product.Price * quantity
                                        };

                                        saleService.Create(sale);
                                        saleService.SaveChanges();
                                        MessageBox.Show("Дані успішно додано!");

                                    }
                                    catch
                                    {
                                        MessageBox.Show("Введені невірні дані!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Задана кількість перевищує доступну!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Кількість має бути числом !!!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Магазин з такою назвою не знайдено");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Покупця не вибрано, або вибрано неіснуючого покупця");
                    }
                }
                else
                {
                    MessageBox.Show("Товар не вибрано, або вибрано неіснуючий товар");
                }
            }
            else
            {
                MessageBox.Show("Заповніть усі поля!");
            }
        }
        public static double GetPrice(object obj, string quntity)
        {
            if(int.TryParse(quntity,out int intQuantity) && obj is ProductDTO product)
            {
                return product.Price * intQuantity;
            }
            else
            {
                return 0;
            }
        }
    }
}

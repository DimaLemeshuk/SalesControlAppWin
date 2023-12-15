using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services.Impl;
using PresentationLayer.Control;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            DBGridControl.AddColumn(dataGrid, "Планована дата\nдоставки", "ScheduledDateTime");
        }

        public static void PrintToDataGridOnlyNotSendOrSend(DataGrid dataGrid, string send)
        {
            DBGridControl.DelOllColumn(dataGrid);
            dataGrid.ItemsSource = new DeliveryService().Find(s => s.Status.Equals(send))
                .ToList();

            DBGridControl.AddColumn(dataGrid, "id", "Id", true);
            DBGridControl.AddColumn(dataGrid, "Товар", "ProductDTO.NameProducts", true);
            DBGridControl.AddColumn(dataGrid, "Дата доставки", "DateTime");
            DBGridControl.AddColumn(dataGrid, "Кількість", "Quantity");
            DBGridControl.AddColumn(dataGrid, "Загальна вартість", "DeliveryCost");
            DBGridControl.AddColumn(dataGrid, "Планована дата\nдоставки", "ScheduledDateTime");
        }

        public static void ChangeStatus(object select, string newStatus)
        {
            if (select != null)
            {
                if (select is DeliveryDTO deliveryDTO)
                {
                    var deliveryService = new DeliveryService();
                    deliveryService.Update(deliveryDTO, "Status", newStatus);
                    deliveryService.Update(deliveryDTO, "DateTime", DateTime.Now);
                    deliveryService.SaveChanges();
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

        public static void AddNew(object _product, DateTime scheduledDateTime, string _quantity, string _deliveryCost)
        {
            if (!(string.IsNullOrWhiteSpace(_quantity) || string.IsNullOrWhiteSpace(_deliveryCost)) && _product != null && scheduledDateTime != null)
            {
                if (Double.TryParse(_deliveryCost.Replace('.', ','), out double deliveryCost))
                {
                    if (int.TryParse(_quantity.Replace('.', ','), out int quantity))
                    {
                        if (scheduledDateTime > DateTime.Now)
                        {
                            if(_product is ProductDTO product)
                            {
                                var productService = new ProductService();
                                var Product = productService.Find(s => s.Id == product.Id).FirstOrDefault();
                                if (Product != null)
                                {
                                    try
                                    {
                                        var deliveryService = new DeliveryService();
                                        var delivery = new DeliveryDTO
                                        {
                                            ProductId = Product.Id,
                                            DeliveryCost = deliveryCost,
                                            ScheduledDateTime = scheduledDateTime,
                                            Quantity = quantity,
                                            Status = "Заплановано"

                                        };
                                        deliveryService.Create(delivery);
                                        deliveryService.SaveChanges();
                                        MessageBox.Show("Дані успішно додано!");

                                    }
                                    catch
                                    {
                                        MessageBox.Show("Введені невірні дані!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Вибрано неіснуючий товар");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Помилка під час пошуку продукту");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Прогнозована дата доставки не може бути в минулому!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("\"Кількість\" - має бути цілим числом!");
                    }
                }
                else
                {
                    MessageBox.Show("\"Вартість\" - має бути числом!");
                }
            }
            else
            {
                MessageBox.Show("Заповніть усі поля!");
            }
        }

    }
}

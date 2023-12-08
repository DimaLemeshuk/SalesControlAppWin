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
            DBGridControl.AddColumn(dataGrid, "Постачальник", "SupplierDTO.NameSuppliers", true);
            DBGridControl.AddColumn(dataGrid, "Категорія", "GroupproductDTO.NameGroupproducts", true);

        }

        public static void AddNew(string nameProduct, string description, string _price, string _availableQuantity, string _suplierId, string _groupProductId)
        {
            if (!(string.IsNullOrWhiteSpace(nameProduct) || string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(_price) || string.IsNullOrWhiteSpace(_availableQuantity) || string.IsNullOrWhiteSpace(_suplierId) || string.IsNullOrWhiteSpace(_groupProductId)))
            {
                if(Double.TryParse(_price.Replace('.', ','), out double price))
                {
                    if (int.TryParse(_availableQuantity.Replace('.', ','), out int availableQuantity))
                    {
                        if (int.TryParse(_suplierId.Replace('.', ','), out int suplierId))
                        {
                            if (int.TryParse(_groupProductId.Replace('.', ','), out int groupProductId))
                            {
                                try
                                {
                                    var productService = new ProductService();
                                    var product = new ProductDTO
                                    {
                                        NameProducts = nameProduct,
                                        Description = description,
                                        Price = price,
                                        AvailableQuantity = availableQuantity,
                                        SuplierId = suplierId,
                                        GroupProductsId = groupProductId
                                    };
                                    if (productService.Find(item => item.NameProducts == nameProduct && item.SuplierId == suplierId).FirstOrDefault() == null)
                                    {
                                        productService.Create(product);
                                        productService.SaveChanges();
                                        MessageBox.Show("Дані успішно додано!");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Схоже що даний товар уже існує\nперегляньте список товарів, та внесіть зміни");
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Введені невірні дані!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("\"Категорія Id \" має бути цілим числом!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("\"Постачальник Id \" має бути цілим числом!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("\"Доступна кількість\" має бути цілим числом!");
                    }
                }
                else
                {
                    MessageBox.Show("\"Ціна\" має бути числом!");
                }
            }
            else
            {
                MessageBox.Show("Заповніть усі поля!");
            }
        }
    }
}

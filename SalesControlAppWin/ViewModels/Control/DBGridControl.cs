using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services.Impl;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace PresentationLayer.Control
{
    internal class DBGridControl
    {
        public static void AddColumn(DataGrid DBGrid, string newName, string PropertyName)
        {

            DBGrid.AutoGenerateColumns = false;
            DBGrid.Columns.Add(new DataGridTextColumn
            {
                Header = newName,
                Binding = new Binding(PropertyName)
            });

        }
        public static void AddColumn(DataGrid DBGrid, string newName, string PropertyName, bool ReadOnly)
        {

            DBGrid.AutoGenerateColumns = false;
            DBGrid.Columns.Add(new DataGridTextColumn
            {
                Header = newName,
                Binding = new Binding(PropertyName),
                IsReadOnly = ReadOnly
            });

        }

        public static void DelOllColumn(DataGrid DBGrid)
        {
            DBGrid.Columns.Clear();
            DBGrid.AutoGenerateColumns = true;
        }

        public static void CopyColumnNames(DataGrid dataGrid1, DataGrid dataGrid2)
        {

            List<string> columnNames = new List<string>();

            // Перевірка, чи імена стовпців були вже отримані

            if (columnNames.Count == 0)
            {
                // Отримати імена стовпців з першого DataGrid (dataGrid1)
                foreach (DataGridColumn column in dataGrid1.Columns)
                {
                    if (column is DataGridTextColumn textColumn)
                    {
                        columnNames.Add(textColumn.Header.ToString());
                    }
                }
            }

            if (dataGrid2.Items.Count == 0)
            {
                DataTable dataTable = new DataTable();
                foreach (string columnName in columnNames)
                {
                    dataTable.Columns.Add(columnName, typeof(string));
                }

                dataGrid2.ItemsSource = dataTable.DefaultView;
            }
        }

        public static void deleteRov(DataGrid DBGrid, System.Object selectedItem)
        {
            try
            {
                if (selectedItem is ProductDTO product)
                {
                    var productService = new ProductService();
                    productService.Delete(product.Id);
                    productService.SaveChanges();
                    MessageBox.Show("Дані успішно видалено");
                }
                else if (selectedItem is CustomerDTO item)
                {
                    var Service = new CustomerService();
                    Service.Delete(item.Id);
                    Service.SaveChanges();
                    MessageBox.Show("Дані успішно видалено");
                }
                else if (selectedItem is DeliveryDTO delivery)
                {
                    var Service = new DeliveryService();
                    Service.Delete(delivery.Id);
                    Service.SaveChanges();
                    MessageBox.Show("Дані успішно видалено");
                }
                else if (selectedItem is GroupproductDTO groupproduct)
                {
                    var Service = new GroupproductService();
                    Service.Delete(groupproduct.Id);
                    Service.SaveChanges();
                    MessageBox.Show("Дані успішно видалено");
                }
                else if (selectedItem is SaleDTO sale)
                {
                    var Service = new SaleService();
                    Service.Delete(sale.Id);
                    Service.SaveChanges();
                    MessageBox.Show("Дані успішно видалено");
                }
                else if (selectedItem is StoreDTO store)
                {
                    var Service = new StoreService();
                    Service.Delete(store.Id);
                    Service.SaveChanges();
                    MessageBox.Show("Дані успішно видалено");
                }
                else if (selectedItem is SupplierDTO supplier)
                {
                    var Service = new SupplierService();
                    Service.Delete(supplier.Id);
                    Service.SaveChanges();
                    MessageBox.Show("Дані успішно видалено");
                }
                else if (selectedItem is UserDTO user)
                {
                    var Service = new UserService();
                    Service.Delete(user.Iduser);
                    Service.SaveChanges();
                    MessageBox.Show("Дані успішно видалено");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Сталася помилка при видаленні : " + ex.Message);
                MessageBox.Show("Неможливо видалити цей рядок,\nоскількі інша таблиця містить посилання на нього");
            }
        }


        public static void updateRow(DataGridCellEditEndingEventArgs e, System.Object editedItem)
        {
            var editedValue = (e.EditingElement as TextBox).Text;// Отримайте значення комірки, яку редагуєте

            try
            {
                if (editedItem is ProductDTO product)
                {
                    var productService = new ProductService();
                    var curr = productService.Get(product.Id);
                    Binding binding = (e.Column as DataGridBoundColumn).Binding as Binding;
                    string propertyName = binding.Path.Path;//змінене поле   
                    productService.Update(curr, propertyName, ConvertToNumberOrString(editedValue));
                    productService.SaveChanges();
                    MessageBox.Show("Зміни успішно збережено");
                }
                else if (editedItem is CustomerDTO customer)
                {
                    var Service = new CustomerService();
                    var curr = Service.Get(customer.Id);
                    Binding binding = (e.Column as DataGridBoundColumn).Binding as Binding;
                    string propertyName = binding.Path.Path;//змінене поле   
                    Service.Update(curr, propertyName, ConvertToNumberOrString(editedValue));
                    Service.SaveChanges();
                    MessageBox.Show("Зміни успішно збережено");
                }
                else if (editedItem is DeliveryDTO delivery)
                {
                    var Service = new DeliveryService();
                    var curr = Service.Get(delivery.Id);
                    Binding binding = (e.Column as DataGridBoundColumn).Binding as Binding;
                    string propertyName = binding.Path.Path;//змінене поле   
                    Service.Update(curr, propertyName, ConvertToNumberOrString(editedValue));
                    Service.SaveChanges();
                    MessageBox.Show("Зміни успішно збережено");
                }
                else if (editedItem is GroupproductDTO groupproduct)
                {
                    var Service = new GroupproductService();
                    var curr = Service.Get(groupproduct.Id);
                    Binding binding = (e.Column as DataGridBoundColumn).Binding as Binding;
                    string propertyName = binding.Path.Path;//змінене поле   
                    Service.Update(curr, propertyName, ConvertToNumberOrString(editedValue));
                    Service.SaveChanges();
                    MessageBox.Show("Зміни успішно збережено");
                }
                else if (editedItem is SaleDTO sale)
                {
                    var Service = new SaleService();
                    var curr = Service.Get(sale.Id);
                    Binding binding = (e.Column as DataGridBoundColumn).Binding as Binding;
                    string propertyName = binding.Path.Path;//змінене поле   
                    Service.Update(curr, propertyName, ConvertToNumberOrString(editedValue));
                    Service.SaveChanges();
                    MessageBox.Show("Зміни успішно збережено");
                }
                else if (editedItem is StoreDTO store)
                {
                    var Service = new StoreService();
                    var curr = Service.Get(store.Id);
                    Binding binding = (e.Column as DataGridBoundColumn).Binding as Binding;
                    string propertyName = binding.Path.Path;//змінене поле   
                    Service.Update(curr, propertyName, ConvertToNumberOrString(editedValue));
                    Service.SaveChanges();
                    MessageBox.Show("Зміни успішно збережено");
                }
                else if (editedItem is SupplierDTO supplier)
                {
                    var Service = new SupplierService();
                    var curr = Service.Get(supplier.Id);
                    Binding binding = (e.Column as DataGridBoundColumn).Binding as Binding;
                    string propertyName = binding.Path.Path;//змінене поле   
                    Service.Update(curr, propertyName, ConvertToNumberOrString(editedValue));
                    Service.SaveChanges();
                    MessageBox.Show("Зміни успішно збережено");
                }
                else if (editedItem is UserDTO user)
                {
                    var Service = new UserService();
                    var curr = Service.Get(user.Iduser);
                    Binding binding = (e.Column as DataGridBoundColumn).Binding as Binding;
                    string propertyName = binding.Path.Path;//змінене поле   
                    Service.Update(curr, propertyName, ConvertToNumberOrString(editedValue));
                    Service.SaveChanges();
                    MessageBox.Show("Зміни успішно збережено");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка при видаленні : " + ex.Message);
            }
        }

        public static void findInDataGrid (string FindText, DataGrid DBGrid)
        {
            string searchText = FindText.ToLower();
            if (!FindText.Equals(""))
            {
                foreach (var item in DBGrid.Items)
                {
                    DataGridRow row = (DataGridRow)DBGrid.ItemContainerGenerator.ContainerFromItem(item);
                    if (row != null)
                    {
                        // Отримуємо значення властивостей об'єкта
                        var propertyValues = item.GetType().GetProperties()
                            .Select(property => property.GetValue(item)?.ToString() ?? "")
                            .ToList();

                        // Перевіряємо, чи будь-яке значення властивості містить текст пошуку
                        if (propertyValues.Any(value => value.ToLower().Contains(searchText)))
                        {
                            row.Background = Brushes.LightGreen;
                        }
                        else
                        {
                            row.Background = Brushes.White;
                        }
                    }
                }
            }
            else
            {
                // Зробити всі поля білими
                foreach (var item in DBGrid.Items)
                {
                    DataGridRow row = (DataGridRow)DBGrid.ItemContainerGenerator.ContainerFromItem(item);
                    if (row != null)
                    {
                        row.Background = Brushes.White;
                    }
                }
            }
        }

        public static object ConvertToNumberOrString(string input)
        {

            if (int.TryParse(input, out int intValue))
            {
                return intValue;
            }

            input = input.Replace('.', ',');
            if (double.TryParse(input, out double doubleValue))
            {
                return doubleValue;
            }

            // Якщо конвертація в int не вдалася, повернемо вихідну строку
            return input;
        }
    }
}

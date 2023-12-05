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
            var productService = new ProductService();

            if (selectedItem is ProductDTO product)
            {
                try
                {
                    productService.Delete(product.Id);
                    productService.SaveChanges();
                    MessageBox.Show("Дані успішно видалено");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сталася помилка при видаленні Product : " + ex.Message);
                }

            }
        }


        public static void updateRow(DataGridCellEditEndingEventArgs e, System.Object editedItem)
        {
            var editedValue = (e.EditingElement as TextBox).Text;// Отримайте значення комірки, яку редагуєте
            var productService = new ProductService();

            if (editedItem is ProductDTO product)
            {
                try
                {
                    var curr = productService.Get(product.Id);
                    Binding binding = (e.Column as DataGridBoundColumn).Binding as Binding;
                    string propertyName = binding.Path.Path;//змінене поле   
                    productService.Update(curr, propertyName, ConvertToNumberOrString(editedValue));
                    productService.SaveChanges();
                    MessageBox.Show("Зміни успішно збережено");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сталася помилка при оновленні: " + ex.Message);
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

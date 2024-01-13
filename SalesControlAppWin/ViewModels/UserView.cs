using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services.Impl;
using PresentationLayer.Control;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace PresentationLayer.ViewModels.Control
{
    public class UserView
    {
        public static void PrintToDataGrid(DataGrid dataGrid)
        {
            if (new UserService().GetCurrentUser().Type.Equals("Admin"))
            {
                DBGridControl.DelOllColumn(dataGrid);
                dataGrid.ItemsSource = new UserService().GetAll()
                    .ToList();

                DBGridControl.AddColumn(dataGrid, "id", "Iduser", true);
                DBGridControl.AddColumn(dataGrid, "Логін", "Login");
                DBGridControl.AddColumn(dataGrid, "Тип", "Type");
            }
            else
            {
                MessageBox.Show("У вас немає доступу до цієї таблиці");
                dataGrid.ItemsSource = null;
            }


        }

        public static bool loginUser(string login, byte[] password)
        {
            if(!string.IsNullOrWhiteSpace(login) && password.Length !=0)
            {
                var userService = new UserService();
                var user = userService.Find(u => u.Login.Equals(login)).FirstOrDefault();
                if(user != null)
                {
                    if(user.Password.Equals(Encoding.UTF8.GetString(password)))
                    {
                        userService.login(user);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Введено невірний пароль!");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Користувач з таким логіном НЕ існує!");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Заповніть усі поля!");
                return false;
            }
        }

        public static void NewUser(string login, byte[] _password, byte[] repeatPassword, string type)
        {
            if (!string.IsNullOrWhiteSpace(login) && _password.Length != 0 && !string.IsNullOrWhiteSpace(type) && repeatPassword.Length !=0)
            {
                var userService = new UserService();
                var user = userService.Find(u => u.Login == login).FirstOrDefault();
                if (user == null)
                {
                    string password = Encoding.UTF8.GetString(_password);
                    if (Enumerable.SequenceEqual(repeatPassword, _password))//Encoding.UTF8.GetString(password)
                    {
                        try
                        {
                            var NewUser = new UserDTO
                            {
                                Login = login,
                                Password = password,
                                Type = type

                            };

                            userService.Create(NewUser);
                            userService.SaveChanges();
                            MessageBox.Show("Користувача успішно зареєстровано!");


                        }
                        catch
                        {
                            MessageBox.Show("Введені невірні дані!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Паролі не співпадають");
                    }
                }
                else
                {
                    MessageBox.Show("Користувач з таким логіном уже існує!");
                }
            }
            else
            {
                MessageBox.Show("Заповніть усі поля!");
            }
        }
    }
}

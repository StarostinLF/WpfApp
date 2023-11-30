using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AdvApp.User_forms
{
    /* Окно со списком пользователей */
    public partial class UserForm : Window
    {
        // Список пользователей
        private List<User> entities;

        public UserForm()
        {
            InitializeComponent();

            entities = XmlDataManager.LoadData<User>("data/Users.xml");
            dataGrid.ItemsSource = entities;
        }

        // Открытие окна с добавлением и отправить данные в таблицу
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm();
            if (addUserForm.ShowDialog() == true)
            {
                User newUser = addUserForm.NewUser;

                if (newUser != null)
                {
                    entities.Add(newUser);
                    XmlDataManager.SaveData("data/Users.xml", entities);
                    dataGrid.Items.Refresh();
                }
            }
        }

        // Удаление выделенной строчки с данными
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is User selectedUser)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить выбранного пользователя?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    entities.Remove(selectedUser);
                    XmlDataManager.SaveData("data/Users.xml", entities);
                    dataGrid.Items.Refresh();
                }
            }
            else MessageBox.Show("Пожалуйста, выберите пользователя для удаления.", "Пользователь не выбран", MessageBoxButton.OK, MessageBoxImage.Hand);
        }

        // Открытие окна с редактированием и отправить новые данные в таблицу
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is User selected)
            {
                EditUserForm editForm = new EditUserForm(selected);

                if (editForm.ShowDialog() == true)
                {
                    int index = entities.IndexOf(selected);

                    entities[index] = editForm.UpdatedUser;
                    XmlDataManager.SaveData("data/Users.xml", entities);
                    dataGrid.Items.Refresh();
                }
            }
        }

        // Поиск в таблице по введенному значению
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();

            List<User> filteredList = entities.Where((User user) =>
            user.Name.ToLower().Contains(searchText) ||
            user.UserId.ToString().Contains(searchText) ||
            user.Login.ToLower().Contains(searchText)).ToList();

            dataGrid.ItemsSource = filteredList;
        }
    }
}
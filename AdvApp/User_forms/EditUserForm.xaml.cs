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
    /* Редактирование данных пользователя */
    public partial class EditUserForm : Window
    {
        // Список пользователей (получение переменных)
        public User UpdatedUser { get; private set; }

        // Отображение исходных данных
        public EditUserForm(User userToEdit)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            UpdatedUser = userToEdit;
            UserIdTextBox.Text = userToEdit.UserId.ToString();
            NameTextBox.Text = userToEdit.Name;
            LoginTextBox.Text = userToEdit.Login;
            PasswordTextBox.Text = userToEdit.Password;
        }

        // Сохранение новых данных в User
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameTextBox.Text) &&
                !string.IsNullOrWhiteSpace(LoginTextBox.Text) &&
                !string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                UpdatedUser.Name = NameTextBox.Text;
                UpdatedUser.Login = LoginTextBox.Text;
                UpdatedUser.Password = PasswordTextBox.Text;

                base.DialogResult = true;
            }
            else MessageBox.Show("Пожалуйста, проверьте введенные данные.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Hand);
        }
    }
}
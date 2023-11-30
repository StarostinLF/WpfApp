﻿using System;
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
    /* Окно c добавлением пользователей */
    public partial class AddUserForm : Window
    {
        // Список пользователей (получение переменных)
        public User NewUser { get; private set; }

        public AddUserForm()
        {
            InitializeComponent();
            
            NewUser = new User();
        }

        // Добавление данных в User
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int userId;

            bool isUserIdValid = int.TryParse(UserIdTextBox.Text, out userId);
            bool isNameValid = !string.IsNullOrWhiteSpace(NameTextBox.Text);
            bool isLoginValid = !string.IsNullOrWhiteSpace(LoginTextBox.Text);
            bool isPasswordValid = !string.IsNullOrWhiteSpace(PasswordBox.Text);

            if (isUserIdValid && isNameValid && isLoginValid && isPasswordValid)
            {
                NewUser = new User
                {
                    UserId = userId,
                    Name = NameTextBox.Text,
                    Login = LoginTextBox.Text,
                    Password = PasswordBox.Text
                };

                base.DialogResult = true;

                Close();
            }
            else MessageBox.Show("Пожалуйста, проверьте введенные данные и попробуйте снова.", "Некорректные данные", MessageBoxButton.OK, MessageBoxImage.Hand);
        }
    }
}
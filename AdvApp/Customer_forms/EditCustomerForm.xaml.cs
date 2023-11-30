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

namespace AdvApp.Customer_forms
{
    /* Редактирование данных заказчиков */
    public partial class EditCustomerForm : Window
    {
        // Список реклам (получение переменных)
        public Customer UpdatedCustomer { get; private set; }

        // Отображение исходных данных
        public EditCustomerForm(Customer customerToEdit)
        {
            InitializeComponent();

            UpdatedCustomer = customerToEdit;
            CustomerIdTextBox.Text = customerToEdit.CustomerId.ToString();
            NameTextBox.Text = customerToEdit.Name;
            BankingDetailsTextBox.Text = customerToEdit.BankingDetails;
            PhoneTextBox.Text = customerToEdit.Phone;
            ContactPersonTextBox.Text = customerToEdit.ContactPerson;
        }

        // Сохранение новых данных в Customer
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameTextBox.Text) &&
                !string.IsNullOrWhiteSpace(BankingDetailsTextBox.Text) &&
                !string.IsNullOrWhiteSpace(PhoneTextBox.Text) &&
                !string.IsNullOrWhiteSpace(ContactPersonTextBox.Text))
            {
                UpdatedCustomer.Name = NameTextBox.Text;
                UpdatedCustomer.BankingDetails = BankingDetailsTextBox.Text;
                UpdatedCustomer.Phone = PhoneTextBox.Text;
                UpdatedCustomer.ContactPerson = ContactPersonTextBox.Text;

                base.DialogResult = true;

                Close();
            }
            else MessageBox.Show("Пожалуйста, проверьте введенные данные.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Hand);
        }
    }
}
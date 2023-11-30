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
using AdvApp.Customer_forms;
using AdvApp.Show_forms;
using AdvApp.User_forms;

/* Главное меню с кнопками */
namespace AdvApp
{
    public partial class MainMenu : Window
    {
        public MainMenu(string userName)
        {
            InitializeComponent();

            UserLabel.Content = "Пользователь: " + userName;

            if (userName.ToLower() != "admin") usrBttn.IsEnabled = false;
        }

        // Передачи
        private void ShowsForm_Button(object sender, RoutedEventArgs e)
        {
            ShowForm form = new ShowForm();

            form.ShowDialog();
        }

        // Реклама
        private void AdvertisementsForm_Button(object sender, RoutedEventArgs e)
        {
            AdvertisementForm advForm = new AdvertisementForm();

            advForm.ShowDialog();
        }

        // Заказчики
        private void CustomersForm_Button(object sender, RoutedEventArgs e)
        {
            CustomerForm form = new CustomerForm();

            form.ShowDialog();
        }

        // Агенты
        private void Agents_Button(object sender, RoutedEventArgs e)
        {
            AgentForm agentForm = new AgentForm();

            agentForm.ShowDialog();
        }

        // Пользователи
        private void Users_Button(object sender, RoutedEventArgs e)
        {
            UserForm form = new UserForm();

            form.ShowDialog();
        }
    }
}
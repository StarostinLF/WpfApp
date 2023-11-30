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

namespace AdvApp.Show_forms
{
    /* Окно c добавлением передачи */
    public partial class AddShowForm : Window
    {
        // Список передач (получение переменных)
        public Show NewShow { get; private set; }

        public AddShowForm()
        {
            InitializeComponent();

            NewShow = new Show();
        }

        // Добавление данных в Show
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(RatingTextBox.Text, out var rating) &&
                int.TryParse(ShowIdTextBox.Text, out var id) &&
                decimal.TryParse(CostPerMinuteTextBox.Text, out var costPerMinute) &&
                !string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                NewShow = new Show
                {
                    ShowId = id,
                    Name = NameTextBox.Text,
                    Rating = rating,
                    CostPerMinute = costPerMinute
                };

                base.DialogResult = true;

                Close();
            }
            else MessageBox.Show("Пожалуйста, проверьте введенные данные и попробуйте снова.", "Некорректные данные", MessageBoxButton.OK, MessageBoxImage.Hand);
        }

        private void ShowIdTextBox_TextChanged(object sender, TextChangedEventArgs e) { }
    }
}
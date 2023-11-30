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
    /* Редактирование данных передачи */
    public partial class EditShowForm : Window
    {
        // Список передач (получение переменных)
        public Show UpdatedShow { get; private set; }

        // Отображение исходных данных
        public EditShowForm(Show showToEdit)
        {
            InitializeComponent();

            UpdatedShow = showToEdit;
            ShowIdTextBox.Text = showToEdit.ShowId.ToString();
            NameTextBox.Text = showToEdit.Name;
            RatingTextBox.Text = showToEdit.Rating.ToString();
            CostPerMinuteTextBox.Text = showToEdit.CostPerMinute.ToString();
        }

        // Сохранение новых данных в Show
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(RatingTextBox.Text, out var rating) &&
                decimal.TryParse(CostPerMinuteTextBox.Text, out var costPerMinute) &&
                !string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                UpdatedShow.Name = NameTextBox.Text;
                UpdatedShow.Rating = rating;
                UpdatedShow.CostPerMinute = costPerMinute;

                base.DialogResult = true;
            }
            else MessageBox.Show("Пожалуйста, проверьте введенные данные.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Hand);
        }
    }
}
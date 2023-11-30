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

namespace AdvApp
{
    /* Редактирование данных рекламы */
    public partial class EditAdvertisementForm : Window
    {
        // Список реклам (получение переменных)
        public Advertisement UpdatedAdvertisement { get; set; }

        // Отображение исходных данных
        public EditAdvertisementForm(Advertisement advertisementToEdit)
        {
            InitializeComponent();

            UpdatedAdvertisement = advertisementToEdit;
            AdIdTextBox.Text = advertisementToEdit.AdId.ToString();
            ShowIdTextBox.Text = advertisementToEdit.ShowId.ToString();
            CustomerIdTextBox.Text = advertisementToEdit.CustomerId.ToString();
            DateDatePicker.SelectedDate = advertisementToEdit.Date;
            DurationTextBox.Text = advertisementToEdit.DurationInMinutes.ToString();
        }

        // Сохранение новых данных в Advertisement
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(AdIdTextBox.Text, out var adId) &&
                int.TryParse(ShowIdTextBox.Text, out var showId) &&
                int.TryParse(CustomerIdTextBox.Text, out var customerId) &&
                DateDatePicker.SelectedDate.HasValue &&
                int.TryParse(DurationTextBox.Text, out var duration))
            {
                UpdatedAdvertisement.AdId = adId;
                UpdatedAdvertisement.ShowId = showId;
                UpdatedAdvertisement.CustomerId = customerId;
                UpdatedAdvertisement.Date = DateDatePicker.SelectedDate.Value;
                UpdatedAdvertisement.DurationInMinutes = duration;

                base.DialogResult = true;
            }
            else MessageBox.Show("Пожалуйста, проверьте введенные данные.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Hand);
        }
    }
}
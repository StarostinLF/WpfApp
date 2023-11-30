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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AdvApp
{
    /* Окно со списком реклам */
    public partial class AdvertisementForm : Window, IComponentConnector
    {
        // Список реклам
        private List<Advertisement> advertisements;

        public AdvertisementForm()
        {
            InitializeComponent();

            advertisements = XmlDataManager.LoadData<Advertisement>("data/Advertisement.xml");
            AdvertisementsDataGrid.ItemsSource = advertisements;
        }

        // Открытие окна с добавлением и отправить данные в таблицу
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddAdvertisementForm addForm = new AddAdvertisementForm();

            if (addForm.ShowDialog() == true)
            {
                Advertisement newAd = addForm.NewAdvertisement;

                advertisements.Add(newAd);
                AdvertisementsDataGrid.Items.Refresh();

                XmlDataManager.SaveData("data/Advertisement.xml", advertisements);
            }
        }

        // Удаление выделенной строчки с данными
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (AdvertisementsDataGrid.SelectedItem is Advertisement selectedAd)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Вы уверены, что хотите удалить выбранное объявление?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    advertisements.Remove(selectedAd);
                    AdvertisementsDataGrid.ItemsSource = null;
                    XmlDataManager.SaveData("data/Advertisement.xml", advertisements);
                    AdvertisementsDataGrid.ItemsSource = advertisements;
                }
            }
            else MessageBox.Show("Пожалуйста, выберите объявление для удаления.", "Объявление не выбрано", MessageBoxButton.OK, MessageBoxImage.Hand);
        }

        // Открытие окна с редактированием и отправить новые данные в таблицу
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (AdvertisementsDataGrid.SelectedItem is Advertisement selectedAd)
            {
                EditAdvertisementForm editForm = new EditAdvertisementForm(selectedAd);

                if (editForm.ShowDialog() == true)
                {
                    int index = advertisements.IndexOf(selectedAd);

                    advertisements[index] = editForm.UpdatedAdvertisement;
                    AdvertisementsDataGrid.Items.Refresh();

                    XmlDataManager.SaveData("data/Advertisement.xml", advertisements);
                }
            }
        }

        // Поиск в таблице по введенному значению
        private void SearchTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();

            List<Advertisement> filteredList = advertisements.Where((Advertisement advertisement) =>
            advertisement.AdId.ToString().Contains(searchText) ||
            advertisement.ShowId.ToString().Contains(searchText) ||
            advertisement.CustomerId.ToString().Contains(searchText) ||
            advertisement.Date.ToString().ToLower().Contains(searchText) ||
            advertisement.DurationInMinutes.ToString().Contains(searchText)).ToList();

            AdvertisementsDataGrid.ItemsSource = filteredList;
        }
    }
}
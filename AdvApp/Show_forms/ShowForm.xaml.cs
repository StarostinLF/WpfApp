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
    /* Окно со списком передач */
    public partial class ShowForm : Window
    {
        // Список передач
        private List<Show> entities;

        public ShowForm()
        {
            InitializeComponent();

            entities = XmlDataManager.LoadData<Show>("data/Shows.xml");
            dataGrid.ItemsSource = entities;
        }

        // Открытие окна с добавлением и отправить данные в таблицу
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddShowForm addShowForm = new AddShowForm();

            if (addShowForm.ShowDialog() == true)
            {
                Show newShow = addShowForm.NewShow;

                if (newShow != null)
                {
                    entities.Add(newShow);
                    XmlDataManager.SaveData("data/Shows.xml", entities);
                    dataGrid.Items.Refresh();
                }
            }
        }

        // Удаление выделенной строчки с данными
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Show selectedShow)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Вы уверены, что хотите удалить выбранное шоу?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    entities.Remove(selectedShow);
                    dataGrid.ItemsSource = null;
                    XmlDataManager.SaveData("data/Shows.xml", entities);
                    dataGrid.ItemsSource = entities;
                }
            }
            else MessageBox.Show("Пожалуйста, выберите шоу для удаления.", "Шоу не выбрано", MessageBoxButton.OK, MessageBoxImage.Hand);
        }

        // Открытие окна с редактированием и отправить новые данные в таблицу
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Show selected)
            {
                EditShowForm editForm = new EditShowForm(selected);

                if (editForm.ShowDialog() == true)
                {
                    int index = entities.IndexOf(selected);

                    entities[index] = editForm.UpdatedShow;
                    dataGrid.Items.Refresh();
                    XmlDataManager.SaveData("data/Shows.xml", entities);
                }
            }
        }

        // Поиск в таблице по введенному значению
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();

            List<Show> filteredList = entities.Where((Show show) =>
            show.Name.ToLower().Contains(searchText) ||
            show.ShowId.ToString().Contains(searchText) ||
            show.Rating.ToString().Contains(searchText) ||
            show.CostPerMinute.ToString().Contains(searchText)).ToList();

            dataGrid.ItemsSource = filteredList;
        }
    }
}
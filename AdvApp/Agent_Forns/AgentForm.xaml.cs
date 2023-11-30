using System.Windows;
using System.Windows.Controls;

namespace AdvApp
{
    /* Окно со списком агентов */
    public partial class AgentForm : Window
    {
        // Список агентов
        private List<Agent> entyties;

        public AgentForm()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            entyties = XmlDataManager.LoadData<Agent>("data/Agents.xml");
            dataGrid.ItemsSource = entyties;
        }

        // Открыть окно с добавлением и отправить данные в таблицу
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddAgentForm addAgentForm = new AddAgentForm();

            if (addAgentForm.ShowDialog() == true)
            {
                Agent newAgent = addAgentForm.NewAgent;

                if (newAgent != null)
                {
                    entyties.Add(newAgent);
                    XmlDataManager.SaveData("data/Advertisement.xml", entyties);
                    dataGrid.Items.Refresh();
                }
            }
        }

        // Удалить выделенную строчку с данными
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Agent selectedAd)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Вы уверены, что хотите удалить выбранное объявление?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    entyties.Remove(selectedAd);
                    dataGrid.ItemsSource = null;
                    XmlDataManager.SaveData("data/Advertisement.xml", entyties);
                    dataGrid.ItemsSource = entyties;
                }
            }
            else MessageBox.Show("Пожалуйста, выберите объявление для удаления.", "Объявление не выбрано", MessageBoxButton.OK, MessageBoxImage.Hand);
        }

        // Открыть окно с редактированием и отправить новые данные в таблицу
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Agent selected)
            {
                EditAgentForm editForm = new EditAgentForm(selected);

                if (editForm.ShowDialog() == true)
                {
                    int index = entyties.IndexOf(selected);
                    entyties[index] = editForm.UpdatedAgent;

                    dataGrid.Items.Refresh();
                    XmlDataManager.SaveData("data/Advertisement.xml", entyties);
                }
            }
        }

        // Поиск в таблице по введенному значению
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();

            List<Agent> filteredList = entyties.Where((Agent agent) =>
            agent.Name.ToLower().Contains(searchText) ||
            agent.AgentId.ToString().Contains(searchText) ||
            agent.CommissionPercentage.ToString().Contains(searchText) ||
            agent.TotalSalesAmount.ToString().Contains(searchText)).ToList();

            dataGrid.ItemsSource = filteredList;
        }
    }
}
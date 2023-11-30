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
    /* Редактирование данных агентов */
    public partial class EditAgentForm : Window
    {
        // Список агентов (получение переменных)
        public Agent UpdatedAgent { get; private set; }

        public EditAgentForm(Agent agentToEdit)
        {
            InitializeComponent();

            UpdatedAgent = agentToEdit;
            AgentIdTextBox.Text = agentToEdit.AgentId.ToString();
            NameTextBox.Text = agentToEdit.Name;
            CommissionPercentageTextBox.Text = agentToEdit.CommissionPercentage.ToString();
            TotalSalesAmountTextBox.Text = agentToEdit.TotalSalesAmount.ToString();
        }

        // Сохранение новых данных в Agent
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(CommissionPercentageTextBox.Text, out var commissionPercentage) &&
                decimal.TryParse(TotalSalesAmountTextBox.Text, out var totalSalesAmount) &&
                !string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                UpdatedAgent.Name = NameTextBox.Text;
                UpdatedAgent.CommissionPercentage = commissionPercentage;
                UpdatedAgent.TotalSalesAmount = totalSalesAmount;

                base.DialogResult = true;
            }
            else MessageBox.Show("Пожалуйста, проверьте введенные данные.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Hand);
        }
    }
}
using System.Windows;

/* Начальное окно */
namespace AdvApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        // Список пользователей
        private List<User> Users { get; set; }

        // Вход в систему
        private void Auth_Button(object sender, RoutedEventArgs e)
        {
            Users = XmlDataManager.LoadData<User>("data/Users.xml");
            User user = Users.FirstOrDefault((User u) => u.Login == loginBox.Text && u.Password == passwordBox.Text);

            if (user != null)
            {
                MainMenu menu = new MainMenu(user.Name, this);

                menu.Show();
                Hide();
            }
        }
    }
}
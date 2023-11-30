using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        // Войти в систему
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
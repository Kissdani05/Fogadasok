using Fogadások.MVVM.ViewModel;
using System.Windows;

namespace Fogadások
{
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;
        }

        // Profil gomb megnyomása (Bejelentkezés megjelenítése)
        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            eventGrid.Visibility = Visibility.Collapsed;
            loginGrid.Visibility = Visibility.Visible;
        }

        // Bejelentkezés gomb megnyomása
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;

            // Ide jönne a bejelentkezési logika (pl. hitelesítés)

            // Sikeres bejelentkezés esetén visszatérünk a főablakra
            eventGrid.Visibility = Visibility.Visible;
            loginGrid.Visibility = Visibility.Collapsed;
        }

        // Kattintható Regisztráció szövegre kattintás
        private void RegistrationLink_Click(object sender, RoutedEventArgs e)
        {
            loginGrid.Visibility = Visibility.Collapsed;
            registrationGrid.Visibility = Visibility.Visible;
        }

        // Regisztráció gomb megnyomása
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string regUsername = regUsernameTextBox.Text;
            string regPassword = regPasswordBox.Password;

            // Ide jönne a regisztráció logika (pl. API-hívás, adatbázis-művelet)

            // Sikeres regisztráció esetén visszatérünk a főablakra
            registrationGrid.Visibility = Visibility.Collapsed;
            eventGrid.Visibility = Visibility.Visible;
        }
    }
}

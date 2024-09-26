using Fogadások.MVVM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Fogadások.MVVM.ViewModel;
using System.Windows.Controls;

namespace Fogadasok.MVVM.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private List<Event> _events;
        private Bettor _currentBettor;
        private string _username;
        private string _password;
        private string _regUsername;
        private string _regPassword;
        private Visibility _eventGridVisibility;
        private Visibility _loginGridVisibility;
        private Visibility _registrationGridVisibility;
        private MainViewModel _viewModel;

        public MainViewModel()
        {
            
            // Default visibility
            EventGridVisibility = Visibility.Visible;
            LoginGridVisibility = Visibility.Collapsed;
            RegistrationGridVisibility = Visibility.Collapsed;

            // Command initialization
            ProfileCommand = new RelayCommand(Profile);
            LoginCommand = new RelayCommand(Login);
            RegisterCommand = new RelayCommand(Register);
            RegistrationLinkCommand = new RelayCommand(ShowRegistration);

            // Load initial data
            LoadData();
        }

        public List<Event> Events
        {
            get { return _events; }
            set
            {
                _events = value;
                OnPropertyChanged(nameof(Events));
            }
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel viewModel)
            {
                var passwordBox = sender as PasswordBox;
                viewModel.RegPassword = passwordBox.Password;  // Frissítjük a ViewModel-ben a jelszót
            }
        }

        public Bettor CurrentBettor
        {
            get { return _currentBettor; }
            set
            {
                _currentBettor = value;
                OnPropertyChanged(nameof(CurrentBettor));
            }
        }

        // Properties for login, registration, and UI visibility
        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public string RegUsername
        {
            get => _regUsername;
            set { _regUsername = value; OnPropertyChanged(nameof(RegUsername)); }
        }

        public string RegPassword
        {
            get => _regPassword;
            set { _regPassword = value; OnPropertyChanged(nameof(RegPassword)); }
        }

        public Visibility EventGridVisibility
        {
            get => _eventGridVisibility;
            set { _eventGridVisibility = value; OnPropertyChanged(nameof(EventGridVisibility)); }
        }

        public Visibility LoginGridVisibility
        {
            get => _loginGridVisibility;
            set { _loginGridVisibility = value; OnPropertyChanged(nameof(LoginGridVisibility)); }
        }

        public Visibility RegistrationGridVisibility
        {
            get => _registrationGridVisibility;
            set { _registrationGridVisibility = value; OnPropertyChanged(nameof(RegistrationGridVisibility)); }
        }

        // Commands
        public ICommand ProfileCommand { get; }
        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand RegistrationLinkCommand { get; }

        // Command methods
        private void Profile()
        {
            EventGridVisibility = Visibility.Collapsed;
            LoginGridVisibility = Visibility.Visible;
        }

        private void Login()
        {
            // Simplified login logic
            if (Username == CurrentBettor.Username && Password == "password") // Placeholder for real authentication
            {
                EventGridVisibility = Visibility.Visible;
                LoginGridVisibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void ShowRegistration()
        {
            LoginGridVisibility = Visibility.Collapsed;
            RegistrationGridVisibility = Visibility.Visible;
        }

        private void Register()
        {
            // Registration logic
            if (!string.IsNullOrEmpty(RegUsername) && !string.IsNullOrEmpty(RegPassword))
            {
                // Ideally, we would make a database call or API request here
                MessageBox.Show("Registration successful!");

                RegistrationGridVisibility = Visibility.Collapsed;
                EventGridVisibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Please fill out all fields.");
            }
        }

        // Load initial data (simulating data from a database or service)
        private void LoadData()
        {
            Events = new List<Event>
            {
                new Event { EventID = 1, EventName = "Football Match", EventDate = DateTime.Now, Category = "Football", Location = "Stadium A", OddsHome = 1.5f, OddsDraw = 3.0f, OddsAway = 2.5f },
                new Event { EventID = 2, EventName = "Basketball Match", EventDate = DateTime.Now, Category = "Basketball", Location = "Arena B", OddsHome = 1.8f, OddsDraw = 3.2f, OddsAway = 2.8f }
            };

            CurrentBettor = new Bettor { Username = "JohnDoe", Balance = 1000 };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

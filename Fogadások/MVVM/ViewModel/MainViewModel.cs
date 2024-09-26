using Fogadások.MVVM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fogadások.MVVM.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private List<Event> _events;
        public List<Event> Events
        {
            get { return _events; }
            set
            {
                _events = value;
                OnPropertyChanged(nameof(Events));
            }
        }

        private Bettor _currentBettor;
        public Bettor CurrentBettor
        {
            get { return _currentBettor; }
            set
            {
                _currentBettor = value;
                OnPropertyChanged(nameof(CurrentBettor));
            }
        }

        public MainViewModel()
        {
            // Load data here from the database
            LoadData();
        }

        private void LoadData()
        {
            // Simulating data load (replace with actual database access)
            Events = new List<Event>
        {
            new Event { EventID = 1, EventName = "Football Match", EventDate = System.DateTime.Now, Category = "Football", Location = "Stadium A", OddsHome = 1.5f, OddsDraw = 3.0f, OddsAway = 2.5f },
            new Event { EventID = 2, EventName = "Basketball Match", EventDate = System.DateTime.Now, Category = "Basketball", Location = "Arena B", OddsHome = 1.8f, OddsDraw = 3.2f, OddsAway = 2.8f }
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

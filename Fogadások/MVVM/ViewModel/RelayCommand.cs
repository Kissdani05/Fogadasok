using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fogadások.MVVM.ViewModel
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;  // A cselekvés, amit a parancs végrehajt
        private readonly Func<bool> _canExecute;  // A feltétel, ami ellenőrzi, hogy végrehajtható-e a parancs

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        // Ezt hívja a WPF, hogy eldöntse, a parancs végrehajtható-e
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        // A tényleges művelet végrehajtása
        public void Execute(object parameter)
        {
            _execute();
        }

        // Ezt akkor hívjuk, ha szeretnénk jelezni, hogy a CanExecute értéke megváltozott
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    }

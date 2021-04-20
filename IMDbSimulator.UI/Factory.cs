using IMDbSimulator.UI.Commands;
using IMDbSimulator.UI.ViewModels;
using System;
using System.Windows.Input;

namespace IMDbSimulator.UI
{
    public class Factory
    {
        private Factory()
        {

        }

        public static MainViewModel GetMainViewModel()
        {
            return new MainViewModel();
        }

        public static ICommand GetRelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            return new RelayCommand(execute, canExecute);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands
{
  public class SearchCommand : ICommand
    {
        public WeatherViewModel ViewModel { get; set; }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public SearchCommand (WeatherViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            string query = parameter as string;

            return !string.IsNullOrWhiteSpace(query);
        }

        public void Execute(object parameter)
        {
            ViewModel.MakeQuery();
        }
    }
}

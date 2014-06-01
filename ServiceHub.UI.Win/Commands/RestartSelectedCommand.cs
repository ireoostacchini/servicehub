using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ServiceHub.UI.Win.ViewModels;
using ServiceHub.Application;


namespace ServiceHub.UI.Commands
{

    public class RestartSelectedCommand : ICommand
    {
        #region Fields

        // Member variables
        private readonly MainViewModel _viewModel;

        #endregion

        #region Constructor

        public RestartSelectedCommand(MainViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        #endregion

        #region ICommand Members

        /// <summary>
        /// Whether this command can be executed.
        /// </summary>
        public bool CanExecute(object parameter)
        {
            //return (_viewModel.SelectedItem != null);
            return true;
        }

        /// <summary>
        /// Fires when the CanExecute status of this command changes.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Invokes this command to perform its intended task.
        /// </summary>
        public void Execute(object parameter)
        {

            var mainVM = (MainViewModel)parameter;
            
            var selected = mainVM.MachineServiceManagerViewModels.Where(x => x.IsSelected).ToList();

            foreach (var vm in selected)
            {
                vm.Restart.Execute(vm);
            }

        }

        #endregion
    }
}

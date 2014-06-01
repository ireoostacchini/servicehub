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
using ServiceHub.UI.Win.ViewModels;

namespace ServiceHub.UI.Commands
{

    public class RestartCommand : ICommand
    {
        #region Fields

        // Member variables
        private readonly MachineServiceManagerViewModel _viewModel;

        #endregion

        #region Constructor

        public RestartCommand(MachineServiceManagerViewModel viewModel)
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

            var managerVM = (MachineServiceManagerViewModel)parameter;

            var backgroundScheduler = TaskScheduler.Default;

            // Construct a task scheduler from the current SynchronizationContext (UI thread)
            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

            // Construct a new TaskFactory using our UI scheduler
            var taskFactory = new TaskFactory(uiScheduler);

            

            taskFactory

                .StartNew(delegate { managerVM.IsRestarting = true; })

                //wiat a bit before updating status
                .ContinueWith(delegate { managerVM.MachineServiceManager.Stop(); Thread.Sleep(1000); }, backgroundScheduler)

                .ContinueWith(delegate { managerVM.UpdateStatus(); })

                //and again
                 .ContinueWith(delegate { managerVM.MachineServiceManager.Start(); Thread.Sleep(2000); }, backgroundScheduler)

                .ContinueWith(delegate { managerVM.IsRestarting = false; })

                .ContinueWith(delegate { managerVM.UpdateStatus(); }

            );

         

        }

        #endregion
    }
}

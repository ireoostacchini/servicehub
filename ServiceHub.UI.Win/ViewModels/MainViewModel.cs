using System.ComponentModel;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Ninject;
using Ninject.Parameters;
using ServiceHub.Infrastructure;
using ServiceHub.Infrastructure.Interfaces;
using ServiceHub.UI.Commands;
using ServiceHub.Application;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;

using ServiceHub.UI.Converters;

using System;

namespace ServiceHub.UI.Win.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields

        // Property variables
        private ObservableCollection<MachineServiceManagerViewModel> _machineServiceManagerViewModels;

        public FilterViewModel FilterViewModel { get; set; }


        #endregion

        #region Constructor

        public MainViewModel()
        {
            this.Initialize();
        }

        #endregion

        #region Command Properties

        public ICommand RestartSelected { get; set; }
 

        #endregion

        #region Properties


        #endregion



        #region Data Properties


        public ObservableCollection<MachineServiceManagerViewModel> MachineServiceManagerViewModels
        {
            get { return _machineServiceManagerViewModels; }

            set
            {
                _machineServiceManagerViewModels = value;
                base.RaisePropertyChangedEvent("MachineServiceManagerList");
            }
        }


  





        #endregion

        #region Event Handlers


        void OnMachineServiceManagerListChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //MessageBox.Show("OnMachineServiceManagerListChanged - " + e.PropertyName );

        }

        void OnMachineServiceManagerChanged(object sender, PropertyChangedEventArgs e)
        {
            //   MessageBox.Show("OnMachineServiceManagerChanged - " + e.PropertyName + " - in ListVM");

        }




        #endregion

        #region Public Methods



        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes this application.
        /// </summary>
        private void Initialize()
        {
            // Initialize commands


            // Create  list
            _machineServiceManagerViewModels = new ObservableCollection<MachineServiceManagerViewModel>();

            // Subscribe to CollectionChanged event
            _machineServiceManagerViewModels.CollectionChanged += OnMachineServiceManagerListChanged;

            // Add items to the list
            foreach (var ms in new Data().MachineServices)
            {

                //this is how we can pass in concrete params into a kernel.Get call
                var machineServiceDtoArg = new ConstructorArgument("machineService", ms);
                var iLoggerArg = new ConstructorArgument("ILogger", Container.Kernel.Get<ILogger>());

                var machineServiceManager = Container.Kernel.Get<MachineServiceManager>(machineServiceDtoArg, iLoggerArg );

                var machineServiceManagerArg = new ConstructorArgument("machineServiceManager", machineServiceManager);

                var machineServiceManagerViewModel =  Container.Kernel.Get<MachineServiceManagerViewModel>(machineServiceManagerArg);

                machineServiceManagerViewModel.PropertyChanged += OnMachineServiceManagerChanged;

                _machineServiceManagerViewModels.Add(machineServiceManagerViewModel);

        

            }


            FilterViewModel = new FilterViewModel(this);


            new Timer(this).Start();

            this.RestartSelected = new RestartSelectedCommand(this);
 

            // Update bindings
            base.RaisePropertyChangedEvent("MachineServiceManagerList");
        }






        #endregion
    }

}
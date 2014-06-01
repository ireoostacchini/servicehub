using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;

using System.Windows;
using System.Diagnostics;
using ServiceHub.Application.Interfaces;
using ServiceHub.UI.Commands;
using ServiceHub.Application;


namespace ServiceHub.UI.Win.ViewModels
{
    public class MachineServiceManagerViewModel : ViewModelBase
    {
        #region Fields

        // Property variables
        public IMachineServiceManager MachineServiceManager { get; set; }

        private bool _isRestarting = false;
        private bool _isSelected = false;
        private bool _isVisible = true;         //all are visible by deafult, until filter is applied
        private IMachineServiceStatus _status;
        private string _statusName;

        #endregion

        #region Constructor

        public MachineServiceManagerViewModel(IMachineServiceManager machineServiceManager)
        {
            this.Initialize();

            MachineServiceManager = machineServiceManager;
        }

        #endregion

        #region Command Properties

        public ICommand Restart { get; set; }

        #endregion

        #region Data Properties


        public IMachineServiceStatus Status
        {
            get
            {
                return _status;

            }

            set
            {
                _status = value;
                this.StatusName = _status.Name;
                base.RaisePropertyChangedEvent("Status");
              
            }
        }

        /// <summary>
        /// This allows us to avoid binding to the (IMachineServiceStatus) interface
        /// Apparently it is possible - http://stackoverflow.com/questions/6431613/how-to-bind-datatrigger-to-an-interface-property
        /// </summary>
        public string StatusName
        {
            get
            {
                return _status.Name;
            }
            set
            {
                _statusName = value;
                base.RaisePropertyChangedEvent("StatusName");
            }
        }


        public string MachineName
        {
            get { 
            
                 var machine = MachineServiceManager.MachineService.Machine;
                return machine.FriendlyName ; 
            }


        }

        public string ServiceName
        {
            get { return MachineServiceManager.MachineService.Service.FriendlyName; }


        }


        public bool IsRestarting
        {
            get { return _isRestarting; }

            set
            {
                _isRestarting = value;
                base.RaisePropertyChangedEvent("IsRestarting");
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }

            set
            {
                _isSelected = value;

                  base.RaisePropertyChangedEvent("IsSelected");
               
            }
        }

        /// <summary>
        /// does the item survive the filtering
        /// </summary>
        public bool IsVisible
        {
            get
            {
                return _isVisible;

            }

            set
            {
                _isVisible = value;
                base.RaisePropertyChangedEvent("IsVisible");

            }
        }


        #endregion

        #region Public Methods

        public void UpdateStatus()
        {
            this.Status = MachineServiceManager.GetStatus();

        
        }





        #endregion

        #region Event Handlers


        void OnMachineServiceManagerChanged(object sender, PropertyChangedEventArgs e)
        {
            //   MessageBox.Show("OnMachineServiceManagerChanged - " + e.PropertyName);

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes this application.
        /// </summary>
        private void Initialize()
        {
            // Initialize commands
            this.Restart = new RestartCommand(this);

            this.PropertyChanged += OnMachineServiceManagerChanged;

  
        }

        #endregion


    }
}
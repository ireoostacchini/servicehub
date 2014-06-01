using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows;
using System.Diagnostics;
using Ninject;
using ServiceHub.DataContracts.Interfaces;
using ServiceHub.UI.Commands;
using ServiceHub.Application;
using ServiceHub.DataContracts;
using ServiceHub.Application;



namespace ServiceHub.UI.Win.ViewModels
{
    public class FilterViewModel : ViewModelBase
    {
        #region Fields

        // Property variables
        public MainViewModel MainViewModel { get; set; }

                private ServiceDto _selectedService;
        private bool _hideRunningServices=false;

        #endregion

        #region Constructor

        public FilterViewModel(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            
            this.Initialize();

   
        }

        #endregion

        #region Command Properties


        #endregion

        #region Public Properties

                public List<ServiceDto> Services
        {
            get
            {
                var nullService = new ServiceDto();        //id will be 0, string properties null 

                var result = Container.Kernel.Get<IData>().Services;

                result.Insert(0,nullService);

                return result;
            }
        }
        

    


        #endregion

        #region Data Properties


              public ServiceDto SelectedService
        {
            get
            {
                return _selectedService;

            }

            set
            {
                _selectedService = value;

                ApplyFilter();

                base.RaisePropertyChangedEvent("SelectedService");

            }
        }

            public bool HideRunningServices
        {
            get
            {
                return _hideRunningServices;

            }

            set
            {
                _hideRunningServices = value;

                ApplyFilter();
                base.RaisePropertyChangedEvent("HideRunningServices");

            }
        }


        #endregion

        #region Public Methods

        
        private void ApplyFilter()
        {
           new Filter(this).ApplyFilter();

        }




        #endregion

        #region Event Handlers


        
        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes this application.
        /// </summary>
        private void Initialize()
        {
   

  
        }

        #endregion


    }
}
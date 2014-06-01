using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Ninject;
using ServiceHub.Application;
using ServiceHub.UI.Interfaces;

using ServiceHub.DataContracts.Interfaces;
using ServiceHub.UI.Win.ViewModels;
using ServiceHub.UI.Win.Views;
using System.Windows.Threading;
using ServiceHub.Infrastructure;
using ServiceHub.Infrastructure.Interfaces;


namespace ServiceHub.UI.Win
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup( StartupEventArgs e)
        {

            LoadData();

            LoadMainView();

        }

        private  void LoadMainView()
        {
            var view = new MainView();
            var viewModel = new MainViewModel();
            view.DataContext = viewModel;
            view.Show();
        }

        void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            string errorMessage = string.Format("An unhandled exception occurred: {0}", e.Exception.Message);

            Container.Kernel.Get<ILogger>().Error(errorMessage);


            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }


        private void LoadData()
        {
            var data = Container.Kernel.Get<IData>();
            
            var config = Container.Kernel.Get<IConfig>();

            new DataProvider(data,config).LoadData();

      
        }

    }
}

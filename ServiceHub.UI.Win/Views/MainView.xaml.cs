using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


using ServiceHub.UI.Win.ViewModels;

namespace ServiceHub.UI.Win.Views
{

    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

        }


        //couldn't manage to bind the datagrid for multiselect, so we amend the VM from code-behind
        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            var addedItems = e.AddedItems.OfType<MachineServiceManagerViewModel>().ToList();

            var removedItems = e.RemovedItems.OfType<MachineServiceManagerViewModel>().ToList();

            foreach (var vm in addedItems)
            {
               vm.IsSelected = true;
            }
            foreach (var vm in removedItems)
            {
               vm.IsSelected = false;
            }



        }



    }





}


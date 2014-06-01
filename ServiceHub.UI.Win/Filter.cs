using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceHub.UI.Win.ViewModels;
using System.ServiceProcess;
using ServiceHub.Application;
using ServiceHub.UI.Win.ViewModels;

namespace ServiceHub.UI.Win
{
   public class Filter
    {

       private FilterViewModel _filterViewModel;

       public Filter(FilterViewModel filterViewModel)
       {
           _filterViewModel = filterViewModel;
       }

       public void ApplyFilter()
       {
           foreach (var vm in _filterViewModel.MainViewModel.MachineServiceManagerViewModels)
           {
               ApplyFilter(vm);

           }
       }




       private void ApplyFilter(MachineServiceManagerViewModel vm)
       {
           var selectedService = _filterViewModel.SelectedService;

           bool result = true;

           //0 = first empty item in combo box - added manually in Services.get. magic number
           if (selectedService != null && selectedService.ServiceId != 0)      
           {
               if (vm.MachineServiceManager.MachineService.Service.ServiceId != selectedService.ServiceId) result = false;
           }


     
           if (_filterViewModel.HideRunningServices)
           {
               if (vm.Status.Id == MachineServiceStatus.Running.Id) result = false;
           }

           vm.IsVisible = result;
       }
    }
}

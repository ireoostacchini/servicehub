using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using System.Windows.Input;
using System.Diagnostics;
using ServiceHub.UI.Win.ViewModels;


namespace ServiceHub.UI.Win
{
    public class Timer
    {
        private MainViewModel _mainViewModel;

        public Timer(MainViewModel mainViewModel)
        {

            _mainViewModel = mainViewModel;
        }

        public void Start()
        {
            //start timer
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(new Config().MonitorInterval);
            timer.Tick += new EventHandler(OnTimerTick);
            timer.Start();

            OnTimerTick(null, null);        //call the handler straight away to update statuses
          
        }

        public void OnTimerTick(object state, EventArgs e)
        {
            foreach (var mSVM in _mainViewModel.MachineServiceManagerViewModels)
            {
                mSVM.UpdateStatus();

                // Forcing the CommandManager to raise the RequerySuggested event
                CommandManager.InvalidateRequerySuggested();

              
            }

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ServiceHub.UI.Win.ViewModels
{



        public abstract class ViewModelBase : INotifyPropertyChanged
        {
            #region INotifyPropertyChanged Members

            public event PropertyChangedEventHandler PropertyChanged;

            #endregion

            #region Protected Methods

            /// <summary>
            /// Fires the PropertyChanged event.
            /// </summary>
            /// <param name="propertyName">The name of the changed property.</param>
            protected void RaisePropertyChangedEvent(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    var e = new PropertyChangedEventArgs(propertyName);
                    PropertyChanged(this, e);
                }
            }

            #endregion
        }
    
}

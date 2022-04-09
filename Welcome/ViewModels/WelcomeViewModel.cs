﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonViewModels;

namespace Welcome.ViewModels
{
    public abstract class WelcomeViewModel : BaseViewModel
    {
        #region CONSTRUCTORS
        public WelcomeViewModel(DelegateCommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
        }
        #endregion

        #region GETTERS/SETTERS
        public DelegateCommand UpdateViewCommand { get; set; }
        #endregion
    }
}

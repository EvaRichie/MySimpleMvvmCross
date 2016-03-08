﻿using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyMvxSimple.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; RaisePropertyChanged(() => FirstName); RaisePropertyChanged(() => FullName); }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; RaisePropertyChanged(() => LastName); RaisePropertyChanged(() => FullName); }
        }

        public string FullName
        {
            get { return string.Format("{1}, {0}", _firstName, _lastName); }
        }

        private bool _IsVisible;

        public bool IsVisible
        {
            get { return _IsVisible; }
            set { _IsVisible = value; RaisePropertyChanged(() => IsVisible); }
        }

        //private MvxCommand _SetVisibleCommand;
        public ICommand SetVisibleCommand
        {
            get
            {
                //_SetVisibleCommand = _SetVisibleCommand ?? new MvxCommand(DoSetVisible);
                //return _SetVisibleCommand;
                return new MvxCommand(DoSetVisible);
            }
        }

        private void DoSetVisible()
        {
            IsVisible = !IsVisible;
        }
    }
}

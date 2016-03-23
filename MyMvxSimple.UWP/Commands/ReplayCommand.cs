﻿using MyMvxSimple.Core.ViewModels;
using MyMvxSimple.UWP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MyMvxSimple.UWP.Commands
{
    public class ReplayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action replayAction;
        public Frame rootFrame = Window.Current.Content as Frame;

        public bool CanExecute(object parameter)
        {
            if (parameter != null)
                return true;
            return false;
        }

        public void Execute(object parameter)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
            replayAction?.Invoke();
            if (parameter is SelectionChangedEventArgs)
            {
                if (rootFrame != null && rootFrame.Content is HttpClientSampleView)
                {
                    var viewModel = (rootFrame.Content as HttpClientSampleView).DataContext as HttpClientSampleViewModel;
                    
                }
            }
        }
    }

    public class ReplayCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action<T> replayAction;

        public bool CanExecute(object parameter)
        {
            if (parameter != null)
                return true;
            return false;
        }

        public void Execute(object parameter)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
            replayAction?.Invoke((T)parameter);
        }
    }
}

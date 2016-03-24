using MyMvxSimple.Core.ViewModels;
using MyMvxSimple.UWP.Views;
using Newtonsoft.Json;
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
    public class TextBoxTextChangCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
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
            if (parameter is string)
            {
                if (rootFrame.Content is HttpClientSampleView)
                {
                    var viewModel = (rootFrame.Content as HttpClientSampleView).DataContext as HttpClientSampleViewModel;
                    viewModel.SearchKeyword = parameter.ToString();
                }
            }
        }
    }
}

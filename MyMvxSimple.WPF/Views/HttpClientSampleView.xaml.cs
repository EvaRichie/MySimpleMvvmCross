using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MvvmCross.Wpf.Views;
using MyMvxSimple.Core.ViewModels;
using System.Windows.Shell;
using System.ComponentModel;

namespace MyMvxSimple.WPF.Views
{
    /// <summary>
    /// Interaction logic for FirstView.xaml
    /// </summary>
    public partial class HttpClientSampleView : MvxWpfView
    {
        public new HttpClientSampleViewModel ViewModel
        {
            get { return (HttpClientSampleViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public HttpClientSampleView()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.SearchKeyword = (sender as TextBox).Text;
        }

        private void ProgressBar_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (ViewModel.IsLoading)
                Application.Current.MainWindow.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Indeterminate;
            else
                Application.Current.MainWindow.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.None;
        }
    }
}

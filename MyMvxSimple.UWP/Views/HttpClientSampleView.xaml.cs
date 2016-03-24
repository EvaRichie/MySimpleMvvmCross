using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MvvmCross.WindowsUWP.Views;
using MyMvxSimple.Core.ViewModels;
using MyMvxSimple.UWP.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMvxSimple.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HttpClientSampleView : MvxWindowsPage
    {
        public HttpClientSampleViewModel pageVM { get; set; }

        public new HttpClientSampleViewModel ViewModel
        {
            get { return (HttpClientSampleViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public HttpClientSampleView()
        {
            this.InitializeComponent();
            this.Loaded += Page_Loaded;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            pageVM = ViewModel;
        }
    }
}

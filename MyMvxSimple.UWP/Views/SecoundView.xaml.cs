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
    public sealed partial class SecoundView : MvxWindowsPage
    {
        public new SecoundViewModel ViewModel
        {
            get { return (SecoundViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public SecoundView()
        {
            this.InitializeComponent();
            this.Loaded += SecoundView_Loaded;
        }

        private void SecoundView_Loaded(object sender, RoutedEventArgs e)
        {
            var extendTitleBar = new ExtendTitleBar();
            extendTitleBar.CoreTitleBarTitle = "TEMPSL";

            UIElement mainContent = this.Content;
            this.Content = null;
            extendTitleBar.SetPageContent(mainContent);
            this.Content = extendTitleBar;

            extendTitleBar.EnableControlsInTitleBar();
        //https://github.com/durow/TestArea/blob/master/UWPTest/TitleBarTest/MainPage.xaml.cs
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.SearchKeyword = (sender as TextBox).Text;
        }
    }
}

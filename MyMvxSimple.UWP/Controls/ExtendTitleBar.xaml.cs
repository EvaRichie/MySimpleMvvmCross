using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace MyMvxSimple.UWP.Controls
{
    public sealed partial class ExtendTitleBar : UserControl, INotifyPropertyChanged
    {
        private UIElement pageContent = null;
        private CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;

        private string _CoreTitleBarTitle;

        public string CoreTitleBarTitle
        {
            get { return _CoreTitleBarTitle; }
            set { _CoreTitleBarTitle = value; NotifyChanged(); }
        }

        public double CoreTitleBarHeight
        {
            get { return coreTitleBar.Height; }
        }

        public Thickness CoreTitleBarPadding
        {
            get
            {
                if (FlowDirection == FlowDirection.LeftToRight)
                {
                    return new Thickness(coreTitleBar.SystemOverlayLeftInset, 0, coreTitleBar.SystemOverlayRightInset, 0);
                }
                else
                {
                    return new Thickness(coreTitleBar.SystemOverlayRightInset, 0, coreTitleBar.SystemOverlayLeftInset, 0);
                }
            }
        }

        public ExtendTitleBar()
        {
            this.InitializeComponent();
        }

        public UIElement SetPageContent(UIElement newContent)
        {
            UIElement oldContent = pageContent;
            if (oldContent != null)
            {
                pageContent = null;
                RootGrid.Children.Remove(oldContent);
            }
            pageContent = newContent;
            if (newContent != null)
            {
                RootGrid.Children.Add(newContent);
                Grid.SetRow((FrameworkElement)pageContent, 1);
            }
            return oldContent;
        }

        public void EnableControlsInTitleBar()
        {
            Window.Current.SetTitleBar(new Grid() { Background = new SolidColorBrush(Windows.UI.Colors.Blue) });
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            coreTitleBar.LayoutMetricsChanged += CoreTitleBar_LayoutMetricsChanged;
            coreTitleBar.IsVisibleChanged += CoreTitleBar_IsVisibleChanged;
            Window.Current.SizeChanged += Current_SizeChanged;

            UpdatePositionAndVisibility();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            coreTitleBar.LayoutMetricsChanged -= CoreTitleBar_LayoutMetricsChanged;
            coreTitleBar.IsVisibleChanged -= CoreTitleBar_IsVisibleChanged;
            Window.Current.SizeChanged -= Current_SizeChanged;
        }

        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            UpdatePositionAndVisibility();
        }

        private void CoreTitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
        {
            NotifyChanged("CoreTitleBarHeight");
            NotifyChanged("CoreTitleBarPadding");
        }

        private void CoreTitleBar_IsVisibleChanged(CoreApplicationViewTitleBar sender, object args)
        {
            UpdatePositionAndVisibility();
        }

        private void UpdatePositionAndVisibility()
        {
            if (ApplicationView.GetForCurrentView().IsFullScreenMode)
            {
                TitleBar.Visibility = coreTitleBar.IsVisible ? Visibility.Visible : Visibility.Collapsed;
                Grid.SetRow(TitleBar, 1);
            }
            else
            {
                TitleBar.Visibility = Visibility.Visible;
                Grid.SetRow(TitleBar, 0);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

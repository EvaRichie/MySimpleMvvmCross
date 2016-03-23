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
using Windows.ApplicationModel.Core;
using MyMvxSimple.UWP.Helpers;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMvxSimple.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BindingSampleView : MvxWindowsPage
    {
        public BindingSampleViewModel bindingVM;

        public new BindingSampleViewModel ViewModel
        {
            get { return (BindingSampleViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }


        public BindingSampleView()
        {
            this.InitializeComponent();
            bindingVM = ViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var adapters = AdaptersHelper.GetAdapters();
            System.Diagnostics.Debug.WriteLine(adapters?.First().Name);
            System.Diagnostics.Debug.WriteLine(adapters?.First().MAC);
            System.Diagnostics.Debug.WriteLine(adapters?.First().Type);
            System.Diagnostics.Debug.WriteLine(adapters?.First().Description);
            //IntPtr ppAvailableNetworkList = new IntPtr();
            //Guid pInterfaceGuid = ((WLAN_INTERFACE_INFO)wlanInterfaceInfoList.InterfaceInfo[0]).InterfaceGuid;
            //WlanGetAvailableNetworkList(ClientHandle, ref pInterfaceGuid, WlanScanInfo.WLAN_AVAILABLE_NETWORK_INCLUDE_ALL_MANUAL_HIDDEN_PROFILES, new IntPtr(), ref ppAvailableNetworkList);
            //WLAN_AVAILABLE_NETWORK_LIST wlanAvailableNetworkList = new WLAN_AVAILABLE_NETWORK_LIST(ppAvailableNetworkList);
            //WlanFreeMemory(ppAvailableNetworkList);
            //for (int j = 0; j < wlanAvailableNetworkList.dwNumberOfItems; j++)
            //{
            //    Interop.WLAN_AVAILABLE_NETWORK network = wlanAvailableNetworkList.wlanAvailableNetwork[j];
            //    Console.WriteLine("Available Network: ");
            //    Console.WriteLine("SSID: " + network.dot11Ssid.ucSSID);
            //    Console.WriteLine("Encrypted: " + network.bSecurityEnabled);
            //    Console.WriteLine("Signal Strength: " + network.wlanSignalQuality);
            //    Console.WriteLine("Default Authentication: " +
            //        network.dot11DefaultAuthAlgorithm.ToString());
            //    Console.WriteLine("Default Cipher: " + network.dot11DefaultCipherAlgorithm.ToString());
            //    Console.WriteLine();
            //}
        }
    }
}

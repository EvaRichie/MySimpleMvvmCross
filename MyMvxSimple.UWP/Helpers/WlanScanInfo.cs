using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyMvxSimple.UWP.Helpers
{
    /// <summary>
    /// Contains an array of NIC information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WLAN_INTERFACE_INFO_LIST
    {
        /// <summary>
        /// Length of <see cref="InterfaceInfo"/> array
        /// </summary>
        public Int32 dwNumberOfItems;
        /// <summary>
        /// This member is not used by the wireless service. Applications can use this member when processing individual interfaces.
        /// </summary>
        public Int32 dwIndex;
        /// <summary>
        /// Array of WLAN interfaces.
        /// </summary>
        public WLAN_INTERFACE_INFO[] InterfaceInfo;

        /// <summary>
        /// Constructor for WLAN_INTERFACE_INFO_LIST.
        /// Constructor is needed because the InterfaceInfo member varies based on how many adapters are in the system.
        /// </summary>
        /// <param name="pList">the unmanaged pointer containing the list.</param>
        public WLAN_INTERFACE_INFO_LIST(IntPtr pList)
        {
            // The first 4 bytes are the number of WLAN_INTERFACE_INFO structures.
            dwNumberOfItems = Marshal.ReadInt32(pList, 0);

            // The next 4 bytes are the index of the current item in the unmanaged API.
            dwIndex = Marshal.ReadInt32(pList, 4);

            // Construct the array of WLAN_INTERFACE_INFO structures.
            InterfaceInfo = new WLAN_INTERFACE_INFO[dwNumberOfItems];

            for (int i = 0; i <= dwNumberOfItems - 1; i++)
            {
                // The offset of the array of structures is 8 bytes past the beginning.
                // Then, take the index and multiply it by the number of bytes in the
                // structure.
                // The length of the WLAN_INTERFACE_INFO structure is 532 bytes - this
                // was determined by doing a Marshall.SizeOf(WLAN_INTERFACE_INFO)
                IntPtr pItemList = new IntPtr(pList.ToInt64() + (i * 532) + 8);

                // Construct the WLAN_INTERFACE_INFO structure, marshal the unmanaged
                // structure into it, then copy it to the array of structures.
                //InterfaceInfo[i] = (WLAN_INTERFACE_INFO)Marshal.PtrToStructure(pItemList, typeof(WLAN_INTERFACE_INFO));
                InterfaceInfo[i] = (WLAN_INTERFACE_INFO)Marshal.PtrToStructure<WLAN_INTERFACE_INFO>(pItemList);
            }
        }
    }

    public class WlanScanInfo
    {
        public const uint WLAN_AVAILABLE_NETWORK_INCLUDE_ALL_ADHOC_PROFILES = 0x00000001;
        public const uint WLAN_AVAILABLE_NETWORK_INCLUDE_ALL_MANUAL_HIDDEN_PROFILES = 0x00000002;

        [DllImport("Wlanapi.dll", SetLastError = true)]
        public static extern uint WlanScan(IntPtr hClientHandle, ref Guid pInterfaceGuid, IntPtr pDot11Ssid, IntPtr pIeData, IntPtr pReserved);

        [DllImport("Wlanapi.dll", SetLastError = true)]
        public static extern uint WlanGetAvailableNetworkList(IntPtr hClientHandle, ref Guid pInterfaceGuid, uint dwFlags, IntPtr pReserved, ref IntPtr ppAvailableNetworkList);
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WLAN_AVAILABLE_NETWORK_LIST
    {
        internal uint dwNumberOfItems;
        internal uint dwIndex;
        internal WLAN_AVAILABLE_NETWORK[] wlanAvailableNetwork;

        internal WLAN_AVAILABLE_NETWORK_LIST(IntPtr ppAvailableNetworkList)
        {
            dwNumberOfItems = (uint)Marshal.ReadInt32(ppAvailableNetworkList);
            dwIndex = (uint)Marshal.ReadInt32(ppAvailableNetworkList, 4);
            wlanAvailableNetwork = new WLAN_AVAILABLE_NETWORK[dwNumberOfItems];

            for (int i = 0; i < dwNumberOfItems; i++)
            {
                //IntPtr pWlanAvailableNetwork = new IntPtr(ppAvailableNetworkList.ToInt32() + i * Marshal.SizeOf(typeof(WLAN_AVAILABLE_NETWORK)) + 8);
                //wlanAvailableNetwork[i] = (WLAN_AVAILABLE_NETWORK)Marshal.PtrToStructure(pWlanAvailableNetwork, typeof(WLAN_AVAILABLE_NETWORK));
                IntPtr pWlanAvailableNetwork = new IntPtr(ppAvailableNetworkList.ToInt32() + i * (Marshal.SizeOf<WLAN_AVAILABLE_NETWORK>() + 8));
                wlanAvailableNetwork[i] = (WLAN_AVAILABLE_NETWORK)Marshal.PtrToStructure<WLAN_AVAILABLE_NETWORK>(pWlanAvailableNetwork);
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WLAN_INTERFACE_INFO
    {
        /// GUID->_GUID
        public Guid InterfaceGuid;

        /// WCHAR[256]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string strInterfaceDescription;

        /// WLAN_INTERFACE_STATE->_WLAN_INTERFACE_STATE
        public WLAN_INTERFACE_STATE isState;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WLAN_AVAILABLE_NETWORK
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string strProfileName;
        public DOT11_SSID dot11Ssid;
        public DOT11_BSS_TYPE dot11BssType;
        public uint uNumberOfBssids;
        public bool bNetworkConnectable;
        public uint wlanNotConnectableReason;
        public uint uNumberOfPhyTypes;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public DOT11_PHY_TYPE[] dot11PhyTypes;
        public bool bMorePhyTypes;
        public uint wlanSignalQuality;
        public bool bSecurityEnabled;
        public DOT11_AUTH_ALGORITHM dot11DefaultAuthAlgorithm;
        public DOT11_CIPHER_ALGORITHM dot11DefaultCipherAlgorithm;
        public uint dwFlags;
        public uint dwReserved;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct DOT11_SSID
    {

        /// ULONG->unsigned int
        public uint uSSIDLength;

        /// UCHAR[]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string ucSSID;
    }

    /// <summary>
    /// Represents an 802.11 Basic Service Set type
    /// </summary>
    public enum DOT11_BSS_TYPE
    {
        ///<summary>
        /// dot11_BSS_type_infrastructure -> 1
        ///</summary>
        dot11_BSS_type_infrastructure = 1,

        ///<summary>
        /// dot11_BSS_type_independent -> 2
        ///</summary>
        dot11_BSS_type_independent = 2,

        ///<summary>
        /// dot11_BSS_type_any -> 3
        ///</summary>
        dot11_BSS_type_any = 3,
    }

    public enum DOT11_PHY_TYPE
    {

        dot11_phy_type_unknown,

        dot11_phy_type_any,

        dot11_phy_type_fhss,

        dot11_phy_type_dsss,

        dot11_phy_type_irbaseband,

        dot11_phy_type_ofdm,

        dot11_phy_type_hrdsss,

        dot11_phy_type_erp,

        dot11_phy_type_ht,

        dot11_phy_type_IHV_start,

        dot11_phy_type_IHV_end,
    }

    public enum DOT11_AUTH_ALGORITHM
    {

        /// DOT11_AUTH_ALGO_80211_OPEN -> 1
        DOT11_AUTH_ALGO_80211_OPEN = 1,

        /// DOT11_AUTH_ALGO_80211_SHARED_KEY -> 2
        DOT11_AUTH_ALGO_80211_SHARED_KEY = 2,

        /// DOT11_AUTH_ALGO_WPA -> 3
        DOT11_AUTH_ALGO_WPA = 3,

        /// DOT11_AUTH_ALGO_WPA_PSK -> 4
        DOT11_AUTH_ALGO_WPA_PSK = 4,

        /// DOT11_AUTH_ALGO_WPA_NONE -> 5
        DOT11_AUTH_ALGO_WPA_NONE = 5,

        /// DOT11_AUTH_ALGO_RSNA -> 6
        DOT11_AUTH_ALGO_RSNA = 6,

        /// DOT11_AUTH_ALGO_RSNA_PSK -> 7
        DOT11_AUTH_ALGO_RSNA_PSK = 7,

        /// DOT11_AUTH_ALGO_IHV_START -> 0x80000000
        DOT11_AUTH_ALGO_IHV_START = -2147483648,

        /// DOT11_AUTH_ALGO_IHV_END -> 0xffffffff
        DOT11_AUTH_ALGO_IHV_END = -1,
    }

    public enum DOT11_CIPHER_ALGORITHM
    {

        /// DOT11_CIPHER_ALGO_NONE -> 0x00
        DOT11_CIPHER_ALGO_NONE = 0,

        /// DOT11_CIPHER_ALGO_WEP40 -> 0x01
        DOT11_CIPHER_ALGO_WEP40 = 1,

        /// DOT11_CIPHER_ALGO_TKIP -> 0x02
        DOT11_CIPHER_ALGO_TKIP = 2,

        /// DOT11_CIPHER_ALGO_CCMP -> 0x04
        DOT11_CIPHER_ALGO_CCMP = 4,

        /// DOT11_CIPHER_ALGO_WEP104 -> 0x05
        DOT11_CIPHER_ALGO_WEP104 = 5,

        /// DOT11_CIPHER_ALGO_WPA_USE_GROUP -> 0x100
        DOT11_CIPHER_ALGO_WPA_USE_GROUP = 256,

        /// DOT11_CIPHER_ALGO_RSN_USE_GROUP -> 0x100
        DOT11_CIPHER_ALGO_RSN_USE_GROUP = 256,

        /// DOT11_CIPHER_ALGO_WEP -> 0x101
        DOT11_CIPHER_ALGO_WEP = 257,

        /// DOT11_CIPHER_ALGO_IHV_START -> 0x80000000
        DOT11_CIPHER_ALGO_IHV_START = -2147483648,

        /// DOT11_CIPHER_ALGO_IHV_END -> 0xffffffff
        DOT11_CIPHER_ALGO_IHV_END = -1,
    }

    /// <summary>
    /// Defines the state of the interface. e.g. connected, disconnected.
    /// </summary>
    public enum WLAN_INTERFACE_STATE
    {
        /// <summary>
        /// wlan_interface_state_not_ready -> 0
        /// </summary>
        wlan_interface_state_not_ready = 0,

        /// <summary>
        /// wlan_interface_state_connected -> 1
        /// </summary>
        wlan_interface_state_connected = 1,

        /// <summary>
        /// wlan_interface_state_ad_hoc_network_formed -> 2
        /// </summary>
        wlan_interface_state_ad_hoc_network_formed = 2,

        /// <summary>
        /// wlan_interface_state_disconnecting -> 3
        /// </summary>
        wlan_interface_state_disconnecting = 3,

        /// <summary>
        /// wlan_interface_state_disconnected -> 4
        /// </summary>
        wlan_interface_state_disconnected = 4,

        /// <summary>
        /// wlan_interface_state_associating -> 5
        /// </summary>
        wlan_interface_state_associating = 5,

        /// <summary>
        /// wlan_interface_state_discovering -> 6
        /// </summary>
        wlan_interface_state_discovering = 6,

        /// <summary>
        /// wlan_interface_state_authenticating -> 7
        /// </summary>
        wlan_interface_state_authenticating = 7,
    }
}

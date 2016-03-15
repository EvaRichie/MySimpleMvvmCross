using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using MyMvxSimple.Core.Services;
using MyMvxSimple.Core.Services.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvxSimple.Core.ViewModels
{
    public class LocationHubSampleViewModel : MvxViewModel
    {
        private double _Lat;

        public double Lat
        {
            get { return _Lat; }
            set { _Lat = value; RaisePropertyChanged(() => Lat); }
        }

        private double _Lng;

        public double Lng
        {
            get { return _Lng; }
            set { _Lng = value; RaisePropertyChanged(() => Lng); }
        }

        private MvxSubscriptionToken _token;

        public LocationHubSampleViewModel(ILocationService location, IMvxMessenger messenger)
        {
            _token = messenger.Subscribe<LocationMessage>(OnLocationMessage);
        }

        private void OnLocationMessage(LocationMessage obj)
        {
            Lat = obj.Lat;
            Lng = obj.Lng;
        }
    }
}

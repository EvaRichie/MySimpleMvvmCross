using MvvmCross.Plugins.Location;
using MvvmCross.Plugins.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvxSimple.Core.Services.DataStore
{
    public class LocationMessage : MvxMessage
    {
        public double Lat { get; private set; }
        public double Lng { get; private set; }

        public LocationMessage(object sender) : base(sender)
        { }

        public LocationMessage(object sender, double lat, double lng) : base(sender)
        {
            Lat = lat;
            Lng = lng;
        }
    }
    
    public class LocationHub : ILocationService
    {
        private readonly IMvxLocationWatcher _watcher;
        private readonly IMvxMessenger _messenger;

        public LocationHub(IMvxLocationWatcher watcher, IMvxMessenger messenger)
        {
            _watcher = watcher;
            _watcher.Start(new MvxLocationOptions(), OnSuccess, OnError);
            _messenger = messenger;
        }

        private void OnError(MvxLocationError Exception)
        {

        }

        private void OnSuccess(MvxGeoLocation Location)
        {
            var message = new LocationMessage(this, Location.Coordinates.Latitude, Location.Coordinates.Longitude);
            _messenger.Publish(message);
        }
    }
}

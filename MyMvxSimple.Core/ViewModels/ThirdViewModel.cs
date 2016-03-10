using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvxSimple.Core.ViewModels
{
    public class ThirdViewModel : MvxViewModel
    {
        private readonly IMvxLocationWatcher _watcher;

        private double _Long;

        public double Long
        {
            get { return _Long; }
            set { _Long = value; RaisePropertyChanged(() => Long); }
        }

        private double _Lat;

        public double Lat
        {
            get { return _Lat; }
            set { _Lat = value; RaisePropertyChanged(() => Lat); }
        }

        public ThirdViewModel(IMvxLocationWatcher watcher)
        {
            _watcher = watcher;
            _watcher.Start(new MvxLocationOptions(), OnSuccess, OnError);
        }

        private void OnSuccess(MvxGeoLocation location)
        {
            Lat = location.Coordinates.Latitude;
            Long = location.Coordinates.Longitude;
        }

        private void OnError(MvxLocationError error)
        {
            Mvx.Error("Location trace error, error code {0}", error.Code);
        }
    }
}

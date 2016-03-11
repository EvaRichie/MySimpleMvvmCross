using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using MyMvxSimple.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvxSimple.Core.ViewModels
{
    public class FourthViewModel : MvxViewModel
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

        public FourthViewModel(ILocationService location, IMvxMessenger messenger)
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

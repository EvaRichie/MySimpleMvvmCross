using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.PictureChooser;
using MyMvxSimple.Core.Services;
using MyMvxSimple.Core.Services.DataStore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyMvxSimple.Core.ViewModels
{
    public class SqliteSampleViewModel : MvxViewModel
    {
        private readonly IDataService _dataService;
        private readonly IKittenService _kittenService;
        //private readonly IMvxPictureChooserTask _pictureChooserTask;

        private string _filter;

        public string Filter
        {
            get { return _filter; }
            set { _filter = value; RaisePropertyChanged(() => Filter); }
        }

        private List<Kitten> _kittens;

        public List<Kitten> Kittens
        {
            get { return _kittens; }
            set { _kittens = value; RaisePropertyChanged(() => Kittens); }
        }

        private Kitten _SelectedKitten;

        public Kitten SelectedKitten
        {
            get { return _SelectedKitten; }
            set { _SelectedKitten = value; RaisePropertyChanged(() => SelectedKitten); }
        }


        private int _kittenCount;

        public int KittenCount
        {
            get { return _kittenCount; }
            set { _kittenCount = value; RaisePropertyChanged(() => KittenCount); }
        }

        private byte[] _pictureBytes;

        public byte[] PictureBytes
        {
            get { return _pictureBytes; }
            set { _pictureBytes = value; RaisePropertyChanged(() => PictureBytes); }
        }


        public ICommand FilterCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    if (Filter != null && Filter != string.Empty)
                    {
                        Kittens = _dataService.Search(Filter);
                    }
                    else
                    {
                        Kittens = _dataService.Search("");
                    }
                });
            }
        }

        public ICommand InserCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    var kitten = _kittenService.CreateNewKitten();
                    _dataService.Insert(kitten);
                    KittenCount = _dataService.Count;
                    Kittens = _dataService.Search("");
                });
            }
        }

        //public ICommand AddPictureCommand
        //{
        //    get
        //    {
        //        return new MvxCommand(() =>
        //        {
        //            _pictureChooserTask.ChoosePictureFromLibrary(400, 95, OnAvaiable, () => { });
        //        });
        //    }
        //}

        private void OnAvaiable(Stream stream)
        {
            using (var mStream = new MemoryStream())
            {
                stream.CopyTo(mStream);
                PictureBytes = mStream.ToArray();
            }
        }

        public SqliteSampleViewModel(IDataService dataService, IKittenService kittenService)
        {
            _dataService = dataService;
            _kittenService = kittenService;
            Kittens = _dataService.Search("");
            KittenCount = _dataService.Count;
        }

        //public SqliteSampleViewModel(IDataService dataService, IKittenService kittenService, IMvxPictureChooserTask pictureChooserTask)
        //{
        //    _dataService = dataService;
        //    _kittenService = kittenService;
        //    _pictureChooserTask = pictureChooserTask;
        //    Kittens = _dataService.Search("");
        //    KittenCount = _dataService.Count;
        //}
    }
}

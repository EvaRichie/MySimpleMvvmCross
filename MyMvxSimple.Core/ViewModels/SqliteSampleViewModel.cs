using MvvmCross.Core.ViewModels;
using MyMvxSimple.Core.Services;
using System;
using System.Collections.Generic;
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

        private int _kittenCount;

        public int KittenCount
        {
            get { return _kittenCount; }
            set { _kittenCount = value; RaisePropertyChanged(() => KittenCount); }
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
                });
            }
        }

        public SqliteSampleViewModel(IDataService dataService, IKittenService kittenService)
        {
            _dataService = dataService;
            _kittenService = kittenService;
            Kittens = _dataService.Search("");
            KittenCount = _dataService.Count;
        }
    }
}

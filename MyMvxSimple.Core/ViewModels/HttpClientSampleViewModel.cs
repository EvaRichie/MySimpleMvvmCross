using MvvmCross.Core.ViewModels;
using MyMvxSimple.Core.Services;
using MyMvxSimple.Core.Services.DataStore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;

namespace MyMvxSimple.Core.ViewModels
{
    public partial class HttpClientSampleViewModel : MvxViewModel, IMvxNotifyPropertyChanged
    {
        private readonly IBooksService _bookService;
        //private readonly SemaphoreSlim mutex = new SemaphoreSlim(1);

        private bool _IsLoading;

        public bool IsLoading
        {
            get { return _IsLoading; }
            set
            {
                _IsLoading = value;
                RaisePropertyChanged(() => IsLoading);
            }
        }

        private float _DelaySecounds;

        public float DelaySecounds
        {
            get { return _DelaySecounds; }
            set { _DelaySecounds = value; RaisePropertyChanged(() => DelaySecounds); }
        }

        private string _PageTitle;

        public string PageTitle
        {
            get { return _PageTitle; }
            set { _PageTitle = value; RaisePropertyChanged(() => PageTitle); }
        }

        private string _SearchKeyword;

        public string SearchKeyword
        {
            get { return _SearchKeyword; }
            set
            {
                if (_SearchKeyword != value)
                {
                    _SearchKeyword = value;
                    RaisePropertyChanged(() => SearchKeyword);
                    UpdateSearchResult();
                }
            }
        }

        private List<Item> _SearchResults;

        public List<Item> SearchResults
        {
            get { return _SearchResults; }
            set { _SearchResults = value; RaisePropertyChanged(() => SearchResults); }
        }

        private Item _SelectedItem;

        public Item SelectedItem
        {
            get { return _SelectedItem; }
            set { _SelectedItem = value; RaisePropertyChanged(() => SelectedItem); }
        }

        public ICommand NavigateCommand
        {
            get { return new MvxCommand(DoNavigation); }
        }

        public ICommand SelectedCommand
        {
            get { return new MvxCommand<Item>(DoSelceted); }
        }

        public HttpClientSampleViewModel(IBooksService bookService)
        {
            _PageTitle = "This is secound page";
            _bookService = bookService;
        }

        private void UpdateSearchResult()
        {
            Task.Run(async () =>
            {
                try
                {
                    //await mutex.WaitAsync().ConfigureAwait(false);
                    await Task.Delay(1000);
                    var searchResult = await _bookService.StartSearchAsync<RootObject>(SearchKeyword).ConfigureAwait(false);
                    SearchResults = searchResult?.items;
                }
                finally
                {
                    //mutex.Release();
                }
            });
        }

        private void DoNavigation()
        {
            ShowViewModel<SqliteSampleViewModel>();
        }

        public void UWP_DoNavigation()
        {
            ShowViewModel<SqliteSampleViewModel>();
        }

        private void DoSelceted(Item selectedItem)
        {
            if (selectedItem != null)
            {
                var itemJson = JsonConvert.SerializeObject(selectedItem);
                ShowViewModel<HttpClientDetailViewModel>(new { jsonObj = itemJson });
            }
            if (_SelectedItem != null)
            {
                var itemJson = JsonConvert.SerializeObject(_SelectedItem);
                ShowViewModel<HttpClientDetailViewModel>(new { jsonObj = itemJson });
            }
        }

        public void UWP_DoSelect(Item selectedItem)
        {
            if (selectedItem != null)
            {
                var itemJson = JsonConvert.SerializeObject(selectedItem);
                ShowViewModel<HttpClientDetailViewModel>(new { jsonObj = itemJson });
            }
        }
    }
}

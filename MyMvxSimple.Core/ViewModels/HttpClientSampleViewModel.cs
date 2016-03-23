﻿using MvvmCross.Core.ViewModels;
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

namespace MyMvxSimple.Core.ViewModels
{
    public class HttpClientSampleViewModel : MvxViewModel
    {
        private readonly IBooksService _bookService;

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
            set { _SearchKeyword = value; RaisePropertyChanged(() => SearchKeyword); Update(); }
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

        private void Update()
        {
            if (IsLoading)
                return;
            Task.Delay(TimeSpan.FromSeconds(1.0)).ContinueWith((t, o) =>
            {
                IsLoading = true;
                _bookService.StartSearchAsync<RootObject>(SearchKeyword, success => { SearchResults = success.items; IsLoading = false; }, fail => { SearchResults = null; IsLoading = false; });
            }, null);
        }

        private void DoNavigation()
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
    }
}

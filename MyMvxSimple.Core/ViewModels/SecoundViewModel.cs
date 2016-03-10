using MvvmCross.Core.ViewModels;
using MyMvxSimple.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvxSimple.Core.ViewModels
{
    public class SecoundViewModel : MvxViewModel
    {
        private readonly IBooksService _bookService;
        private readonly object _lockObj = new object();

        private bool _IsLoading;

        public bool IsLoading
        {
            get { return _IsLoading; }
            set { _IsLoading = value; RaisePropertyChanged(() => IsLoading); }
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

        public SecoundViewModel(IBooksService bookService)
        {
            _PageTitle = "This is secound page";
            _bookService = bookService;
        }

        private void Update()
        {
            lock (_lockObj)
            {
                System.Diagnostics.Debug.WriteLine("Before " + DateTime.Now.ToLocalTime().ToString());
                Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith((t, o) =>
                {
                    System.Diagnostics.Debug.WriteLine("Get async download http" + DateTime.Now.ToLocalTime().ToString());
                    _bookService.StartSearchAsync<RootObject>(SearchKeyword, success => { SearchResults = success.items; }, fail => { });
                }, null);
            }
        }
    }
}

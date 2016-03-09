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

        private readonly IBooksService _bookService;

        public SecoundViewModel(IBooksService bookService)
        {
            _PageTitle = "This is secound page";
            _bookService = bookService;
        }

        private void Update()
        {
            _bookService.StartSearchAsync<RootObject>(SearchKeyword, success => { SearchResults = success.items; }, fail => { });
        }
    }
}

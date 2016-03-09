using MvvmCross.Platform.Platform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyMvxSimple.Core.Services
{
    //public class BookService : IBooksService
    //{
    //    private readonly ISimpleRestService _restService;

    //    public BookService(ISimpleRestService restService)
    //    {
    //        _restService = restService;
    //    }

    //    public void StartSearchAsync(string whatFor, Action<RootObject> success, Action<Exception> error)
    //    {
    //        var address = string.Format("https://www.googleapis.com/books/v1/volumes?q={0}", Uri.EscapeUriString(whatFor));
    //        _restService.MakeRequest(address, "GET", success, error);
    //    }
    //}

    public class BookService : IBooksService
    {
        private readonly IHttpClientService _httpClientService;

        public BookService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public void StartSearchAsync(string whatFor, Action<RootObject> success, Action<Exception> error)
        {
            var address = string.Format("https://www.googleapis.com/books/v1/volumes?q={0}", Uri.EscapeUriString(whatFor));
            _httpClientService.DownloadAsStringAsync(address, success, error);
        }
    }
}

using MvvmCross.Platform.Platform;
using MyMvxSimple.Core.Services.DataStore;
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

        public void StartSearch(string whatFor, Action<RootObject> success, Action<Exception> error)
        {
            System.Diagnostics.Debug.WriteLine("Searching for {0}", whatFor);
            var address = string.Format("https://www.googleapis.com/books/v1/volumes?q={0}", Uri.EscapeUriString(whatFor));
            _httpClientService.Download(address, success, error);
        }

        public async Task StartSearchAsync<T>(string whatFor, Action<T> successAction, Action<Exception> exceptionAction)
        {
            System.Diagnostics.Debug.WriteLine("Searching for {0}", whatFor);
            var address = string.Format("https://www.googleapis.com/books/v1/volumes?q={0}", Uri.EscapeUriString(whatFor));
            var asyncResult = await _httpClientService.DownloadAsync<T>(address).ConfigureAwait(continueOnCapturedContext: false);
            if (asyncResult != null && asyncResult is T)
            {
                successAction((T)asyncResult);
            }
            else
            {
                exceptionAction((Exception)asyncResult);
            }
        }

        public async Task<T> StartSearchAsync<T>(string whatFor)
        {
            System.Diagnostics.Debug.WriteLine("Searching for {0}", whatFor);
            var address = string.Format("https://www.googleapis.com/books/v1/volumes?q={0}", Uri.EscapeUriString(whatFor));
            var asyncResult = await _httpClientService.DownloadAsync<T>(address).ConfigureAwait(false);
            return (T)asyncResult;
        }
    }
}

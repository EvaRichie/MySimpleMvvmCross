using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvxSimple.Core.Services
{
    public interface IHttpClientService
    {
        void Download<T>(string requestUriString, Action<T> success, Action<Exception> error);
        Task<object> DownloadAsync<T>(string requestUriString);
    }
}

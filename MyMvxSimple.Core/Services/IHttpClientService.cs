using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvxSimple.Core.Services
{
    public interface IHttpClientService
    {
        //Task<T> DownloadAsStringAsync<T>(string requestUriString, out Exception error);
        void DownloadAsStringAsync<T>(string requestUriString, Action<T> success, Action<Exception> error);
    }
}

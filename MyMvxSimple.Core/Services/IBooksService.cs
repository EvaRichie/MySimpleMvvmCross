using MyMvxSimple.Core.Services.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvxSimple.Core.Services
{
    public interface IBooksService
    {
        void StartSearch(string whatFor, Action<RootObject> success, Action<Exception> error);
        void StartSearchAsync<T>(string whatFor, Action<T> successAction, Action<Exception> exceptionAction);
    }
}

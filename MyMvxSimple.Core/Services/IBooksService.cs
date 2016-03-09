using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvxSimple.Core.Services
{
    public interface IBooksService
    {
        void StartSearchAsync(string whatFor, Action<RootObject> success, Action<Exception> error);
    }
}

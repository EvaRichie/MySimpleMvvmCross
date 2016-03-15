using MyMvxSimple.Core.Services.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvxSimple.Core.Services
{
    public interface ICollectedItemService
    {
        List<CollectedItem> All();
        void Add(CollectedItem collectedItem);
        void Update(CollectedItem collectedItem);
        void Delete(CollectedItem collectedItem);
    }
}

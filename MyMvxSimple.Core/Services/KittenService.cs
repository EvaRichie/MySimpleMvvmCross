using MyMvxSimple.Core.Services.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvxSimple.Core.Services
{
    public class KittenService : IKittenService
    {
        private readonly List<string> _names = new List<string>() { "MSFT", "APPLE", "GOOGLE", "INTEL", "AMD", "NVIDIA" };

        public Kitten CreateNewKitten(string extra = "")
        {
            return new Kitten()
            {
                name = _names[new Random().Next(0, _names.Count)] + extra,
                imageUrl = string.Format("http://placekitten.com/{0}/{0}",new Random().Next(0,500)),
                price = new Random(23).Next()
            };
        }
    }
}

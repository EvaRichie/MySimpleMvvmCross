using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvxSimple.Core.Services.DataStore
{
    public class Offer
    {
        public int finskyOfferType { get; set; }
        public ListPrice2 listPrice { get; set; }
        public RetailPrice2 retailPrice { get; set; }
    }
}

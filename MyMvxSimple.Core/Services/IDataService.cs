using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvxSimple.Core.Services
{
    public interface IDataService
    {
        List<Kitten> Search(string nameFilter);
        void Insert(Kitten kitten);
        void Update(Kitten kitten);
        void Delete(Kitten kitten);
        int Count { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDal
{
    // Design Pattern :- Generic Repository Pattern
    public interface IDal<AnyType>
    {
        void Add(AnyType obj);
        void Update(AnyType obj);
        List<AnyType> Search();
        void Save();
    }
}

using InterfaceDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDAL
{
    public abstract class AbstractDal<AnyType> : IDal<AnyType>
    {
        protected string ConnectionString = "";
        protected List<AnyType> AnyTypes = new List<AnyType>();
        public AbstractDal(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
        public virtual void Add(AnyType obj)
        {
            AnyTypes.Add(obj);
        }

        public virtual void Save()
        {
            throw new NotImplementedException();
        }

        public virtual List<AnyType> Search()
        {
            throw new NotImplementedException();
        }

        public virtual void Update(AnyType obj)
        {
            throw new NotImplementedException();
        }
    }
}

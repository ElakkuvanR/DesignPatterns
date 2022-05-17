using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceCustomer
{
    // Design Pattern : Stratergy Pattern - It helps to choose the algorithms dynamically
    public interface IValidation<AnyType>
    {
        void Validate(AnyType obj);
    }
}

using MiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryCustomer
{
    public static class Factory // Design Pattern: Simple Factory Pattern
    {
        private static Dictionary<string, CustomerBase> availableRoles = new Dictionary<string, CustomerBase>();

        public static CustomerBase Create(string CustomerType)
        {
            // Design Patter: Lazy Loading
            if (availableRoles.Count() == 0)
            {
                availableRoles.Add("Customer", new Customer());
                availableRoles.Add("Lead", new Lead());
            }
            // Design Pattern: RIP Replace If with Polymorphism
            return availableRoles[CustomerType];
        }
    }
}

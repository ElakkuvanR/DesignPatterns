using InterfaceCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using MiddleLayer;
using ValidationAlgorithms;

namespace FactoryCustomer
{
    public static class Factory // Design Pattern: Simple Factory Pattern
    {
        private static IUnityContainer availableRoles = null;

        public static ICustomer Create(string CustomerType)
        {
            // Design Patter: Lazy Loading
            if (availableRoles == null)
            {
                availableRoles = new UnityContainer();
                availableRoles.RegisterType<ICustomer, Customer>("Customer", new InjectionConstructor(new CustomerValidation()));
                availableRoles.RegisterType<ICustomer, Lead>("Lead", new InjectionConstructor(new LeadValidation()));
            }
            // Design Pattern: RIP Replace If with Polymorphism
            return availableRoles.Resolve<ICustomer>(CustomerType);
        }
    }
}

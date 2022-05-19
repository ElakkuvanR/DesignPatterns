using InterfaceCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using MiddleLayer;
using ValidationAlgorithms;
using InterfaceDal;
using CommonDAL;

namespace FactoryCustomer
{
    public static class Factory<AnyType> // Design Pattern: Simple Factory Pattern
    {
        private static IUnityContainer Objects = null;

        public static AnyType Create(string Type)
        {
            // Design Pattern: Lazy Loading
            if (Objects == null)
            {
                Objects = new UnityContainer();
                Objects.RegisterType<ICustomer, Customer>("Customer", new InjectionConstructor(new CustomerValidation()));
                Objects.RegisterType<ICustomer, Lead>("Lead", new InjectionConstructor(new LeadValidation()));
            }
            // Design Pattern: RIP Replace If with Polymorphism
            return Objects.Resolve<AnyType>(Type);
        }
    }
}

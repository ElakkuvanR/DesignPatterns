using AdoDotnetDal;
using InterfaceCustomer;
using InterfaceDal;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDal
{
    public static class FactoryDal<AnyType>
    {
        private static IUnityContainer Objects = null;

        public static AnyType Create(string Type)
        {
            // Design Pattern: Lazy Loading
            if (Objects == null)
            {
                Objects = new UnityContainer();
                Objects.RegisterType<IDal<ICustomer>, CustomerDAL>("AdoDal");
            }
            // Design Pattern: RIP Replace If with Polymorphism
            return Objects.Resolve<AnyType>(Type,
                    new ResolverOverride[]
                    {
                        new ParameterOverride("_ConnectionString"
                            ,@"Data Source=1LP8453\SQLEXPRESS;Initial Catalog=CustomerDB(DesignPattern);Integrated Security=True;")
                    });
        }
    }
}

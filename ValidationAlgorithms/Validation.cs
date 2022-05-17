using InterfaceCustomer;
using System;

namespace ValidationAlgorithms
{
    public class CustomerValidation : IValidation<ICustomer>
    {
        public void Validate(ICustomer obj)
        {
            if (obj.CustomerName.Length == 0)
            {
                throw new Exception("Customer Name is required");
            }
            if (obj.PhoneNumber.Length == 0)
            {
                throw new Exception("PhoneNumber is required");
            }
            if (obj.BillAmount == 0)
            {
                throw new Exception("BillAmount is required");
            }
            if (obj.BillDate >= DateTime.Now)
            {
                throw new Exception("BillDate is required");
            }
            if (obj.Address.Length == 0)
            {
                throw new Exception("Address is required");
            }
        }
    }

    public class LeadValidation : IValidation<ICustomer>
    {
        public void Validate(ICustomer obj)
        {
            if (obj.CustomerName.Length == 0)
            {
                throw new Exception("Customer Name is required");
            }
            if (obj.PhoneNumber.Length == 0)
            {
                throw new Exception("PhoneNumber is required");
            }
        }
    }
}

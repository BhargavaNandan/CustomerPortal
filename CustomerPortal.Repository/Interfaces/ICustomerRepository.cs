using CustomerPortal.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerPortal.Repository
{
    public interface ICustomerRepository
    {
        void Insert(TblCustomer entity);
    }
}

using CustomerPortal.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerPortal.Repository
{
    public interface ICustomerRepository
    {
        List<TblCustomer> Insert(List<TblCustomer> entity);
    }
}

using CustomerPortal.Data.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CustomerPortal.Business.Interfaces
{
    public interface ICustomerService
    {
        List<TblCustomer> CustomerData(IFormFile file, decimal amount);
    }
}

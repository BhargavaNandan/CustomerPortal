using CustomerPortal.Business.Interfaces;
using CustomerPortal.Data.Models;
using CustomerPortal.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CustomerPortal.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository dataAccess)
        {
            _customerRepository = dataAccess;
        }
        public List<TblCustomer> CustomerData(IFormFile file, decimal amount)
        {
            try
            {
                var result = new StringBuilder();
                List<TblCustomer> customers = new List<TblCustomer>();
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    while (reader.Peek() >= 0)
                    {
                        var line = reader.ReadLine();
                        string[] splitChars = line.Split(',');
                        TblCustomer customer = new TblCustomer();
                        if (!splitChars[0].Contains('#') && Convert.ToDecimal(splitChars[3]) > amount)
                        {
                            customer.Id = Convert.ToInt32(splitChars[0]);
                            customer.CustomerTypeId = Convert.ToInt32(splitChars[1]);
                            customer.Name = splitChars[2];
                            customer.Amount = Convert.ToDecimal(splitChars[3]);
                            var charsToRemove = new string[] { "[", "]", "(", ")" };
                            foreach (var c in charsToRemove)
                            {
                                splitChars[4] = splitChars[4].Replace(c, string.Empty);
                            }
                            customer.Date = Convert.ToDateTime(splitChars[4]);
                            customers.Add(customer);
                        }
                        //result.AppendLine(reader.ReadLine());
                    }
                    return _customerRepository.Insert(customers);
                }
            }
            catch(Exception E)
            {
                throw new Exception(E.Message);
            }
        }
    }
}

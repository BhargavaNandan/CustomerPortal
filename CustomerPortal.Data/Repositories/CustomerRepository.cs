using CustomerPortal.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CustomerPortal.Repository.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        internal CustomerContext _context;
        internal DbSet<TblCustomer> _dbSet;

        public CustomerRepository(CustomerContext context)
        {
                _context = context;
                _dbSet = context.Set<TblCustomer>();
        }
        public List<TblCustomer> Insert(List<TblCustomer> entities)
        {
            try
            {
                foreach(var entity in entities)
                {
                    _dbSet.Add(entity);
                }
                _context.SaveChanges();
                return entities;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

using CustomerPortal.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerPortal.Repository.Repositories
{
    public class CustomerRepository
    {
        internal CustomerContext _context;
        internal DbSet<TblCustomer> _dbSet;
        public void Insert(TblCustomer entity)
        {
            try
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

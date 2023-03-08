using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ESFE.ArqLimpia.EN.Interfaces;

namespace ESFE.ArqLimpia.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ESFEDbContext dbContext;
        public UnitOfWork(ESFEDbContext pDbContext)
        {
            dbContext = pDbContext;
        }
        public Task<int> SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();
        }
    }
}

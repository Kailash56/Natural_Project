using Microsoft.EntityFrameworkCore;
using Natural_Core;
using Natural_Core.Models;
using Natural_Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Natural_Data.Repositories
{
    public class DistributorRepository : Repository<Distributor> ,IDistributorRepository
    {
        public DistributorRepository(NaturalsContext context) : base(context)
        {

        }   
        public async Task<IEnumerable<Distributor>> GetAllDistributorstAsync()
        {
            return await NaturalDbContext.Distributors.Include(m => m.Id).ToListAsync();
        }

        public async Task<Distributor> GetWithDistributorsByIdAsync(string id)
        {
            return await NaturalDbContext.Distributors.Include(m =>m.Id).SingleOrDefaultAsync();
        }
     
        private NaturalsContext NaturalDbContext
        {
            get { return Context as NaturalsContext; }
        }

  
    }
}

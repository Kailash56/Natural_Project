﻿using Natural_Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Natural_Core.Repositories
{
    public interface IDistributorRepository : IRepository<Distributor>
    {
      
       Task<IEnumerable<Distributor>> GetAllDistributorstAsync();
        Task<Distributor> GetWithDistributorsByIdAsync(string id);

    }
}

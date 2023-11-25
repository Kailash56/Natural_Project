using Natural_Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Natural_Core.Services
{
    public interface IDistributorService
    {
         Task<DistributorResponse> CreateDistributorAsync(Distributor distributor);
        Task SetAssociatedEntities(Distributor distributor, string areaId, string cityId, string stateId);
        Task<IEnumerable<Distributor>> GetAllDistributors();

    }
}

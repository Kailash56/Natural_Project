using Natural_Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Natural_Core.Repositories
{
    public interface IAreaRepository : IRepository<Area> 
    {

        Task<IEnumerable<Area>> GetAllAreasAsync();
    }
}

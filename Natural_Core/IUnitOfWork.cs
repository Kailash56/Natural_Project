using Natural_Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Natural_Core
{
    public interface IUnitOfWork : IDisposable
    {
        ILoginRepository Login { get; }
        IDistributorRepository DistributorRepo { get; }
        ICityRepository CityRepo { get; }
        IStateRepository StateRepo { get; }
        IAreaRepository AreaRepo { get; }
        Task<int> CommitAsync();


    }
}

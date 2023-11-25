using Natural_Core;
using Natural_Core.Repositories;
using Natural_Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Natural_Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NaturalsContext _context;
        private ILoginRepository _loginRepository;
        private IDistributorRepository _distributorRepository;
        private ICityRepository _cityRepository;
        private IAreaRepository _areaRepository;
        private IStateRepository _stateRepository;


        public UnitOfWork(NaturalsContext context)
        {
            _context = context;
        }
      
        public ILoginRepository Login => _loginRepository = _loginRepository ?? new LoginRepository(_context);
        public IDistributorRepository DistributorRepo => _distributorRepository = _distributorRepository ?? new DistributorRepository(_context);

        public ICityRepository CityRepo => _cityRepository = _cityRepository ?? new CityRepository(_context);
        public IStateRepository StateRepo => _stateRepository = _stateRepository ?? new StateRepository(_context);

        public IAreaRepository AreaRepo => _areaRepository = _areaRepository ?? new AreaRepository(_context);


        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}





















































































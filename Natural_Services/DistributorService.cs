using Natural_Core;
using Natural_Core.Models;
using Natural_Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace Natural_Services
{
    public class DistributorService : IDistributorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DistributorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Distributor>> GetAllDistributors()
        {
            return await _unitOfWork.DistributorRepo.GetAllAsync();
        }
        public async Task SetAssociatedEntities(Distributor distributor, string areaId, string cityId, string stateId)
        {

            distributor.Area = await _unitOfWork.AreaRepo.GetByIdAsync(areaId);

            distributor.City = await _unitOfWork.CityRepo.GetByIdAsync(cityId);

            distributor.State = await _unitOfWork.StateRepo.GetByIdAsync(stateId);

        }
        public async Task<DistributorResponse> CreateDistributorAsync(Distributor distributor)
        {
            var Response = new DistributorResponse();
            try
            {
                await _unitOfWork.DistributorRepo.AddAsync(distributor);
                var created = await _unitOfWork.CommitAsync();
                if (created != null)
                {
                    Response.Message = "Insertion Successful";
                    Response.StatusCode = 200;
                }

            }

            catch (Exception ex)
            {
                Response.Message = "Insertion Failed";
                Response.StatusCode = 401;
            }
            return Response;
        }
    }
}

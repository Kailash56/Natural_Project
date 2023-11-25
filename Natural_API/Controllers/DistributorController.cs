using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Natural_API.Resources;
using Natural_Core.Models;
using Natural_Core.Repositories;
using Natural_Core.Services;
using Natural_Services;

namespace Natural_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributorController : ControllerBase
    {

        private readonly IDistributorService _DistributorService;
        private readonly IMapper _mapper;
        public DistributorController (IDistributorService DistributorService, IMapper mapper)
        {
            _DistributorService = DistributorService;
            _mapper = mapper;
           
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DistributorResource>>> GetDistributors()
        {
            var distributors = await _DistributorService.GetAllDistributors();
            var distributorResources = _mapper.Map<IEnumerable<Distributor>,IEnumerable<DistributorResource>>(distributors);
            return Ok(distributorResources);
        }

        [HttpPost]
        public async Task<ActionResult<DistributorResourceResponse>> InsertDistributor([FromBody] DistributorResource distributorResource)

        {
            var distributor = _mapper.Map<DistributorResource,Distributor>(distributorResource);

            await _DistributorService.SetAssociatedEntities(distributor, distributorResource.AreaId, distributorResource.CityId, distributorResource.StateId);
            var createDistributorResponse=  await _DistributorService.CreateDistributorAsync(distributor);
            var mappedResponse = _mapper.Map<DistributorResponse,DistributorResourceResponse>(createDistributorResponse);
            return StatusCode(createDistributorResponse.StatusCode,mappedResponse);
        }
    }
}

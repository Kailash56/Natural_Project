﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Natural_API.Resources;
using Natural_Core.Models;
using Natural_Core.Services;

namespace Natural_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _areaService;
        private readonly IMapper _mapper;

        public AreaController(IAreaService areaService, IMapper mapper)
        {
            _areaService = areaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task <ActionResult<IEnumerable<Area>>> GetAreasList()
        {
            var areas = await _areaService.GetAreasAsync();
            var AreasList = _mapper.Map<IEnumerable<Area>,IEnumerable<AreaResource>>(areas);
            return Ok(AreasList);
        }
            
    }
}

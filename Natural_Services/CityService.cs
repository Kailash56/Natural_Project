﻿using Natural_Core;
using Natural_Core.Models;
using Natural_Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace Natural_Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<City>> GetCitiesAsync()
        {

            return await _unitOfWork.CityRepo.GetAllAsync();

        }
    }
}
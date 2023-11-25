﻿using Natural_Core;
using Natural_Core.Services;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Natural_Core.Models;
using System.Net.Http.Headers;
using System;
using System.Security.Claims;
using System.Security.AccessControl;


#nullable disable

namespace Natural_Services
{
    public class LoginService : ILoginService
    {

        private readonly IUnitOfWork _unitOfWork;

        public LoginService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }  
        public async Task<Response> LoginAsync(Login credentials)
        {

            Response response = new Response();
            try
            {
                var user = await _unitOfWork.Login.GetAllAsync();

                var authenticatedUser = user.FirstOrDefault(u => u.UserName == credentials.UserName && u.Password == credentials.Password);

               
                if (authenticatedUser != null)
                {
                                      
                   response.FirstName = authenticatedUser.FirstName;
                    response.LastName = authenticatedUser.LastName;
                    response.StatusCode = 200;
                    response.Message = "LOGIN SUCCESSFUL";
                }

                else
                {
                    response.StatusCode = 401;
                    response.Message = "INVALID CREDENTIALS";

                }        
              
            }

            catch (Exception ex)
            {
                response.Message = "INTERNAL SERVER ERROR";
                response.StatusCode = 500;
            }
            return response;

        }
    }          
}

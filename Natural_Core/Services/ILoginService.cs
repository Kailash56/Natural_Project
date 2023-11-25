﻿using Natural_Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Natural_Core.Services
{
    public interface ILoginService 
    {
        public Task<Response> LoginAsync(Login credentials);

    }
}

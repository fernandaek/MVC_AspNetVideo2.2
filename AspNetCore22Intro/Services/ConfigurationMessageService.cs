﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore22Intro.Services
{
    public class ConfigurationMessageService : IMessageService
    {
        private readonly IConfiguration _configuration;

        public ConfigurationMessageService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetMessage()
        {
            return _configuration["Message"];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIServiceLayer.Adapter;
using APIServiceLayer.Configuration;
using APIServiceLayer.Models;

namespace APIServiceLayer.Facade
{
    public class StudlyApiServiceFacade : StudlyApiBaseService
    {

        public StudlyApiServiceFacade(IApiHttpAdapter adapter, ConfigurationApiLinks links) : base(adapter, links)
        {

        }

        public override Task<string?> Login(UserLoginDto user)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> Register(UserRegisterDto data)
        {
            throw new NotImplementedException();
        }

        public override Task<UserDTO?> GetUserData(string token)
        {
            throw new NotImplementedException();
        }
    }
}

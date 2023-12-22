using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIServiceLayer.Adapter;
using APIServiceLayer.Configuration;
using APIServiceLayer.Models;
using Blazored.LocalStorage;

namespace APIServiceLayer.Facade
{
    public class StudlyApiServiceFacade : StudlyApiBaseService
    {

        public StudlyApiServiceFacade(IApiHttpAdapter adapter, ApiEndpoints links) : base(adapter, links)
        {

        }



        public override async Task<TokenDto?> Login(UserLoginDto user)
        {
            return await Adapter.PostAsync<UserLoginDto, TokenDto>($"{Links.EndpointApiBaseUrl()}{Links.Login}", user);
        }

        public override async Task Register(UserRegisterDto data)
        {
            await Adapter.PostAsync<UserRegisterDto, UserDTO>($"{Links.EndpointApiBaseUrl()}{Links.Customer}", data);
        }

        public override async Task<UserDTO?> GetUserData()
        {
            return await Adapter.GetAsync<UserDTO>($"{Links.EndpointApiBaseUrl()}{Links.Customer}");
        }
    }
}

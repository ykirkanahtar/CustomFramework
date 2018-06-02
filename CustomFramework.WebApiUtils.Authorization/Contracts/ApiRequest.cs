﻿using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Contracts
{
    public class ApiRequest : IApiRequest
    {
        public ApiRequest(User user, ClientApplication clientApplication)
        {
            User = user;
            ClientApplication = clientApplication;
        }

        public User User { get; set; }

        public ClientApplication ClientApplication { get; set; }
    }
}
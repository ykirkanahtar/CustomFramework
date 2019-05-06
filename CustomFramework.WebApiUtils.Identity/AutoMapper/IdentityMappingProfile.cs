using System;
using System.Security.Claims;
using AutoMapper;
using CustomFramework.WebApiUtils.Identity.Contracts.Requests;
using CustomFramework.WebApiUtils.Identity.Contracts.Responses;
using CustomFramework.WebApiUtils.Identity.Models;

namespace CustomFramework.WebApiUtils.Identity.AutoMapper
{
    public class IdentityMappingProfile : Profile
    {
        public void Map()
        {
            CreateMap<ClientApplication, ClientApplicationResponse>();
            CreateMap<ClientApplicationRequest, ClientApplication>();

            CreateMap<Claim, ClaimResponse>();
            CreateMap<ClaimRequest, Claim>();
        }
    }
}
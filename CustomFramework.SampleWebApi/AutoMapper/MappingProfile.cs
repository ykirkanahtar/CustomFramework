using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Request;
using CustomFramework.SampleWebApi.Response;
using CustomFramework.WebApiUtils.Authorization.AutoMapper;

namespace CustomFramework.SampleWebApi.AutoMapper
{
    public class MappingProfile : AuthorizationMappingProfile
    {
        public MappingProfile()
        {
            Map();

            CreateMap<Match, MatchResponse>();
            CreateMap<MatchRequest, Match>();

            CreateMap<Player, PlayerResponse>();
            CreateMap<PlayerRequest, Player>();

            CreateMap<Stat, StatResponse>();
            CreateMap<StatRequest, Stat>();

            CreateMap<Team, TeamResponse>();
            CreateMap<TeamRequest, Team>();
        }
    }
}
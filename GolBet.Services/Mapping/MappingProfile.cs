// GolBet.Services/Mapping/MappingProfile.cs
using AutoMapper;
using GolBet.Entities;
using GolBet.Services.DTOs;

namespace GolBet.Services.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Match, MatchDto>();

        CreateMap<Match, MatchDetailDto>()
            .ForMember(dto => dto.TotalBets, //Destino
                options => options.MapFrom(match => /*mapeo*/
                    match.Bets.Count));      //Origen

        CreateMap<Team, TeamDto>();
        CreateMap<TeamFormDto, Team>().ReverseMap();
        CreateMap<MatchFormDto, Match>().ReverseMap();

        CreateMap<Bet, BetDto>()
            .ForMember(dto => dto.PotentialPayout,
               options => options.MapFrom(bet => bet.Amount * bet.OddsAtPlacement));
    }
}

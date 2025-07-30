using AutoMapper;
using Mattis.Api.Main.Dto;
using Mattis.Api.Main.Model;

namespace Mattis.Api.Main.Business
{
    public class ApiMainProfile : Profile
    {
        public ApiMainProfile()
        {
            CreateMap<PlayerDao, PlayerResponse>()
                    .ForMember(dest => dest.Age, opt => opt.MapFrom(src => GetAge(src.BirthDate)));

            CreateMap<PlayerInput, PlayerDao>();
        }

        private int GetAge(DateTime birthDate)
        {
            var today = DateTime.Now.Date;

            var age = today.Year - birthDate.Year;

            if (today.AddYears(-age) < birthDate)
                age--;

            return age;
        }
    }
}
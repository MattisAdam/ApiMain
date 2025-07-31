using ApiTest.Dto;
using ApiTest.Model;
using AutoMapper;
using MediatR;
namespace ApiTest.Business.Person
{
   public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonDao, PersonResponse>();
            CreateMap<PersonInput, PersonDao>();

        }
    }
}

using ApiTest.Dto;
using ApiTest.Model;
using AutoMapper;
namespace ApiTest.Business
{
   public class ApiTestProfile : Profile
    {
        public ApiTestProfile()
        {
            CreateMap<PersonDao, PersonResponse>();
            CreateMap<PersonInput, PersonDao>();

        }
    }
}   

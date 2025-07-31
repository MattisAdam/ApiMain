using ApiTest.Dto;
using AutoMapper;
using MediatR;
using ApiTest.Db.UnitOfWork;
using Microsoft.AspNetCore.Http.HttpResults;
namespace ApiTest.Business.Person.Query
{
    public class GetPersonByIdQuery : IRequest<PersonResponse>
    {
        public int Id { get; set; }
    }

    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, PersonResponse>
    {
        readonly IApiTestUnitOfWork _apiTestUnitOfWork;
        readonly IMapper _mapper;

        public GetPersonByIdQueryHandler(
            IApiTestUnitOfWork apiTestUnitOfWork, IMapper mapper)
        {
            _apiTestUnitOfWork = apiTestUnitOfWork;
            _mapper = mapper;
        }
    

        public async Task<PersonResponse> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _apiTestUnitOfWork.PersonRepository.GetByIdAsync(request.Id);

            var result = _mapper.Map<PersonResponse>(data);
            return result;
        }
    }
}

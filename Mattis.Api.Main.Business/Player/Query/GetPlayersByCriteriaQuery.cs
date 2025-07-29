using AutoMapper;
using Mattis.Api.Main.Db.UnitOfWork;
using Mattis.Api.Main.Dto;
using MediatR;

namespace Mattis.Api.Main.Business.Player.Query
{
    public class GetPlayersByCriteriaQuery : PlayerCriteria, IRequest<IEnumerable<PlayerResponse>>
    {
    }

    public class GetPlayersByCriteriaQueryHandler : IRequestHandler<GetPlayersByCriteriaQuery, IEnumerable<PlayerResponse>>
    {
        readonly IApiMainUnitOfWork _apiMainUnitOfWork;
        readonly IMapper _mapper;

        public GetPlayersByCriteriaQueryHandler(
            IApiMainUnitOfWork apiMainUnitOfWork,
            IMapper mapper)
        {
            _apiMainUnitOfWork = apiMainUnitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlayerResponse>> Handle(GetPlayersByCriteriaQuery request, CancellationToken cancellationToken)
        {
            var data = await _apiMainUnitOfWork.PlayerRepository.GetByCriteriaAsync(request);

            if (data == null)
                return new List<PlayerResponse>();

            var result = _mapper.Map<IEnumerable<PlayerResponse>>(data);
            return result;
        }
    }
}
using AutoMapper;
using Mattis.Api.Main.Db.UnitOfWork;
using Mattis.Api.Main.Dto;
using MediatR;

namespace Mattis.Api.Main.Business.Player.Query
{
    public class GetPlayerByIdQuery : IRequest<PlayerResponse?>
    {
        public int Id { get; set; }
    }

    public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, PlayerResponse?>
    {
        readonly IApiMainUnitOfWork _apiMainUnitOfWork;
        readonly IMapper _mapper;

        public GetPlayerByIdQueryHandler(
            IApiMainUnitOfWork apiMainUnitOfWork,
            IMapper mapper)
        {
            _apiMainUnitOfWork = apiMainUnitOfWork;
            _mapper = mapper;
        }

        public async Task<PlayerResponse?> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _apiMainUnitOfWork.PlayerRepository.GetByIdAsync(request.Id);

            if (data == null)
                return null;

            var result = _mapper.Map<PlayerResponse>(data);
            return result;
        }
    }
}
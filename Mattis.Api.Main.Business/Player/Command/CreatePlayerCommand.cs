using AutoMapper;
using Mattis.Api.Main.Db.UnitOfWork;
using Mattis.Api.Main.Dto;
using Mattis.Api.Main.Model;
using MediatR;

namespace Mattis.Api.Main.Business.Player.Command
{
    public class CreatePlayerCommand : PlayerInput, IRequest<int>
    {
    }

    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, int>
    {
        readonly IApiMainUnitOfWork _apiMainUnitOfWork;
        readonly IMapper _mapper;

        public CreatePlayerCommandHandler(
            IApiMainUnitOfWork apiMainUnitOfWork,
            IMapper mapper)
        {
            _apiMainUnitOfWork = apiMainUnitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<PlayerDao>(request);
            data.IsActive = true;

            await _apiMainUnitOfWork.PlayerRepository.AddAndSaveAsync(data);

            return data.Id;
        }
    }
}
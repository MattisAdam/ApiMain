using AutoMapper;
using Mattis.Api.Main.Db.UnitOfWork;
using Mattis.Api.Main.Dto;
using Mattis.Api.Main.Model;
using MediatR;

namespace Mattis.Api.Main.Business.Player.Command
{
    public class UpdatePlayerCommand : PlayerInput, IRequest<int>
    {
    }

    public class UpdatePlayerCommandHandler : IRequestHandler<UpdatePlayerCommand, int>
    {
        readonly IApiMainUnitOfWork _apiMainUnitOfWork;
        readonly IMapper _mapper;

        public UpdatePlayerCommandHandler(
            IApiMainUnitOfWork apiMainUnitOfWork,
            IMapper mapper)
        {
            _apiMainUnitOfWork = apiMainUnitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
        {
            var data = await _apiMainUnitOfWork.PlayerRepository.GetByIdAsync(request.Id, false);

            if (data == null)
                throw new Exception("Probleme :(");

            _mapper.Map<PlayerInput, PlayerDao>(request, data);

            await _apiMainUnitOfWork.SaveChangesAsync();

            return data.Id;
        }
    }
}
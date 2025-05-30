using JadooProject.DataAccess.Context;
using JadooProject.Features.Mediator.Commands.SubscribeCommands;
using MediatR;
using NuGet.Protocol.Plugins;

namespace JadooProject.Features.Mediator.Handlers.SubscribeHandlers
{
    public class UpdateSubscribeCommandHandler : IRequestHandler<UpdateSubscribeCommand>
    {
        private readonly JadooContext _context;

        public UpdateSubscribeCommandHandler(JadooContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateSubscribeCommand request, CancellationToken cancellationToken)
        {
            var subscribe = _context.Subscribes.FirstOrDefault(x => x.SubscribeId == request.SubscribeId);
            if (subscribe != null)
            {
                subscribe.Email = request.Email;
                _context.Subscribes.Update(subscribe);
                await _context.SaveChangesAsync();
            }
        }
    }
}

using JadooProject.DataAccess.Context;
using JadooProject.Features.CQRS.Commands.DestinationCommands;
using JadooProject.Features.Mediator.Commands.SubscribeCommands;
using MediatR;

namespace JadooProject.Features.Mediator.Handlers.SubscribeHandlers
{
    public class RemoveSubscribeCommandHandler : IRequestHandler<RemoveSubscribeCommand>
    {
        private readonly JadooContext _context;

        public RemoveSubscribeCommandHandler(JadooContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveSubscribeCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Subscribes.FindAsync(request.Id);

            _context.Subscribes.Remove(values);
            await _context.SaveChangesAsync();
        }
    }
}

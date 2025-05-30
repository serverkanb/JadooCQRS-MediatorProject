using JadooProject.DataAccess.Context;
using JadooProject.DataAccess.Entities;
using JadooProject.Features.Mediator.Commands.SubscribeCommands;
using MediatR;

namespace JadooProject.Features.Mediator.Handlers.SubscribeHandlers
{
    public class CreateSubscribeCommandHandler : IRequestHandler<CreateSubscribeCommand>
    {
        private readonly JadooContext _context;

        public CreateSubscribeCommandHandler(JadooContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateSubscribeCommand request, CancellationToken cancellationToken)
        {
            var subscribe = new Subscribe
            {
                Email = request.Email
            };
            await _context.Subscribes.AddAsync(subscribe);
            await _context.SaveChangesAsync();
        }
    }
}

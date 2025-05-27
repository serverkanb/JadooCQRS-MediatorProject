using JadooProject.DataAccess.Context;
using JadooProject.DataAccess.Entities;
using JadooProject.Features.Mediator.Commands.ServiceCommands;
using MediatR;

namespace JadooProject.Features.Mediator.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly JadooContext _context;

        public UpdateServiceCommandHandler(JadooContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = new Service
            {
                ServiceId = request.ServiceId,
                Description = request.Description,
                Title = request.Title,
                Icon = request.Icon
            };
            _context.Update(service);
            await _context.SaveChangesAsync();
        }
    }
}

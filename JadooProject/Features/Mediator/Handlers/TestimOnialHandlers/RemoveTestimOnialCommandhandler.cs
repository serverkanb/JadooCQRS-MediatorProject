using JadooProject.DataAccess.Context;
using JadooProject.Features.Mediator.Commands.TesstimOnialCommands;
using MediatR;

namespace JadooProject.Features.Mediator.Handlers.TestimOnialHandlers
{
    public class RemoveTestimOnialCommandHandler : IRequestHandler<RemoveTestimOnialCommand>
    {
        private readonly JadooContext _context;

        public RemoveTestimOnialCommandHandler(JadooContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveTestimOnialCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TestimOnials.FindAsync(request.Id);
            if (entity != null)
            {
                _context.TestimOnials.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

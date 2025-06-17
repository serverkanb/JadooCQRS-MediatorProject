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
            var value = _context.TestimOnials.Find(request.Id);
            if (value == null)
            {
                throw new Exception("Silinecek testimonial bulunamadı.");
            }
            _context.TestimOnials.Remove(value);
            await _context.SaveChangesAsync();

        }
    }
}

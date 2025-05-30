using JadooProject.DataAccess.Context;
using JadooProject.DataAccess.Entities;
using JadooProject.Features.Mediator.Commands.TesstimOnialCommands;
using MediatR;

namespace JadooProject.Features.Mediator.Handlers.TestimOnialHandlers
{
    public class CreateTestimOnialCommandHandler : IRequestHandler<CreateTestimOnialCommand>
    {
        private readonly JadooContext _context;

        public CreateTestimOnialCommandHandler(JadooContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateTestimOnialCommand request, CancellationToken cancellationToken)
        {
            var testimonial = new Testimonial
            {
                Name = request.Name,
                Location=request.Location,
                Comment = request.Comment,
                ImageUrl = request.ImageUrl
            };

            await _context.TestimOnials.AddAsync(testimonial);
            await _context.SaveChangesAsync();
        }
    }
}

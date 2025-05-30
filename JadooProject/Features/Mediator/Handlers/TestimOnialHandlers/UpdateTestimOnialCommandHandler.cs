using JadooProject.DataAccess.Context;
using JadooProject.DataAccess.Entities;
using JadooProject.Features.Mediator.Commands.TesstimOnialCommands;
using MediatR;

namespace JadooProject.Features.Mediator.Handlers.TestimOnialHandlers
{
    public class UpdateTestimOnialCommandHandler : IRequestHandler<UpdateTestimOnialCommand>
    {
        private readonly JadooContext _context;

        public UpdateTestimOnialCommandHandler(JadooContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateTestimOnialCommand request, CancellationToken cancellationToken)
        {
            var entity = new Testimonial
            {
                TestimonialId = request.TestimOnialId,
                Name = request.Name,
                Location = request.Location,
                Comment = request.Comment,
                ImageUrl = request.ImageUrl
            };

            _context.TestimOnials.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

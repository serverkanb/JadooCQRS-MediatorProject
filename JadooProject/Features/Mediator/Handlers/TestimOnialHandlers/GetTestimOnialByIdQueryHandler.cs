using JadooProject.DataAccess.Context;
using JadooProject.DataAccess.Entities;
using JadooProject.Features.Mediator.Queries.TestimOnialQueries;
using JadooProject.Features.Mediator.Results.TestimOnialResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JadooProject.Features.Mediator.Handlers.TestimOnialHandlers
{
    public class GetTestimOnialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimOnialByIdQueryResult>
    {
        private readonly JadooContext _context;

        public GetTestimOnialByIdQueryHandler(JadooContext context)
        {
            _context = context;
        }

        public async Task<GetTestimOnialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.TestimOnials.FirstOrDefaultAsync(x => x.TestimonialId == request.Id);

            

            return new GetTestimOnialByIdQueryResult
            {
                TestimonialId = value.TestimonialId,
                Name = value.Name,
                Location = value.Location,
                Comment = value.Comment,
                ImageUrl = value.ImageUrl
            };
        }
    }





}

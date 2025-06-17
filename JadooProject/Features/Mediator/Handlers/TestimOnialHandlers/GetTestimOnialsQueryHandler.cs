using JadooProject.DataAccess.Context;
using JadooProject.DataAccess.Entities;
using JadooProject.Features.Mediator.Queries.TestimOnialQueries;
using JadooProject.Features.Mediator.Results.ServiceResults;
using JadooProject.Features.Mediator.Results.TestimOnialResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JadooProject.Features.Mediator.Handlers.TestimOnialHandlers
{
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimOnialQueryResult>>
    {
        private readonly JadooContext _context;

        public GetTestimonialQueryHandler(JadooContext context)
        {
            _context = context;
        }

        public async Task<List<GetTestimOnialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = _context.TestimOnials.ToList();

            var result = values.Select(x => new GetTestimOnialQueryResult
            {
                TestimonialId = x.TestimonialId,    
                Name = x.Name,
                Comment = x.Comment,
                ImageUrl = x.ImageUrl,
                Location = x.Location
            }).ToList();

            return result;
        }
    }
}

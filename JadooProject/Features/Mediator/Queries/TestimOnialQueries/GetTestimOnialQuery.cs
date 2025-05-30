using JadooProject.DataAccess.Entities;
using JadooProject.Features.Mediator.Results.TestimOnialResults;
using MediatR;

namespace JadooProject.Features.Mediator.Queries.TestimOnialQueries
{
    public class GetTestimonialQuery : IRequest<List<GetTestimOnialQueryResult>>
    {
    }
}

using JadooProject.Features.Mediator.Results.TestimOnialResults;
using MediatR;

namespace JadooProject.Features.Mediator.Queries.TestimOnialQueries
{

    public class GetTestimonialByIdQuery : IRequest<GetTestimOnialByIdQueryResult>
    {
        public int Id { get; set; }

        public GetTestimonialByIdQuery(int id)
        {
            Id = id;
        }
    }

}

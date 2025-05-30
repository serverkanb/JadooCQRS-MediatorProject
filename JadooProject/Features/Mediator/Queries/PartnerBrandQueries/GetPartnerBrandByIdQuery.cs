using JadooProject.Features.Mediator.Results.PartnerBrandResults;
using MediatR;

namespace JadooProject.Features.Mediator.Queries.PartnerBrandQueries
{
    public class GetPartnerBrandByIdQuery : IRequest<GetPartnerBrandByIdQueryResult>
    {
        public int Id { get; set; }

        public GetPartnerBrandByIdQuery(int id)
        {
            Id = id;
        }
    }
}

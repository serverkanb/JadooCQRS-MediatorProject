using JadooProject.Features.Mediator.Results.PartnerBrandResults;
using MediatR;

namespace JadooProject.Features.Mediator.Queries.PartnerBrandQueries
{
    public class GetPartnerBrandQuery : IRequest<List<GetPartnerBrandQueryResult>> { }

}

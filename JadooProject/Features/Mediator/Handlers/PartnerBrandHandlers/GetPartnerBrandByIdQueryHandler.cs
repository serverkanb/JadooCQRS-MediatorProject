using JadooProject.DataAccess.Context;
using JadooProject.Features.Mediator.Queries.PartnerBrandQueries;
using JadooProject.Features.Mediator.Results.PartnerBrandResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JadooProject.Features.Mediator.Handlers.PartnerBrandHandlers
{
    public class GetPartnerBrandByIdQueryHandler : IRequestHandler<GetPartnerBrandByIdQuery, GetPartnerBrandByIdQueryResult>
    {
        private readonly JadooContext _context;

        public GetPartnerBrandByIdQueryHandler(JadooContext context)
        {
            _context = context;
        }

        public async Task<GetPartnerBrandByIdQueryResult> Handle(GetPartnerBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.PartnerBrands.FirstOrDefaultAsync(x => x.PartnerBrandId == request.Id);

            return new GetPartnerBrandByIdQueryResult
            {
                PartnerBrandId = value.PartnerBrandId,
                LogoUrl = value.LogoUrl
            };
        }
    }
}

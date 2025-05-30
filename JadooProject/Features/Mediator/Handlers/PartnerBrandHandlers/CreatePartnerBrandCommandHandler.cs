using JadooProject.DataAccess.Context;
using JadooProject.Features.Mediator.Queries.PartnerBrandQueries;
using JadooProject.Features.Mediator.Results.PartnerBrandResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JadooProject.Features.Mediator.Handlers.PartnerBrandHandlers
{
    public class CreatePartnerBrandCommandHandler : IRequestHandler<GetPartnerBrandQuery, List<GetPartnerBrandQueryResult>>
    {
        private readonly JadooContext _context;

        public CreatePartnerBrandCommandHandler(JadooContext context)
        {
            _context = context;
        }

        public async Task<List<GetPartnerBrandQueryResult>> Handle(GetPartnerBrandQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.PartnerBrands.ToListAsync();

            return values.Select(x => new GetPartnerBrandQueryResult
            {
                PartnerBrandId = x.PartnerBrandId,
                LogoUrl = x.LogoUrl
            }).ToList();
        }
    }
}

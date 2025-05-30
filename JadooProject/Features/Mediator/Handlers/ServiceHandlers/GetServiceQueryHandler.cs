using JadooProject.DataAccess.Context;
using JadooProject.Features.Mediator.Queries.ServiceQueries;
using JadooProject.Features.Mediator.Results.ServiceResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JadooProject.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly JadooContext _context;

        public GetServiceQueryHandler(JadooContext context)
        {
            _context = context;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {

            var values = await _context.Services.ToListAsync();

            var serviceList = (from x in values
                               select new GetServiceQueryResult()
                               {
                                   Description = x.Description,
                                   Icon = x.Icon,
                                   ServiceId = x.ServiceId,
                                   Title = x.Title
                               }).ToList();
            return serviceList;
        }
    }
}

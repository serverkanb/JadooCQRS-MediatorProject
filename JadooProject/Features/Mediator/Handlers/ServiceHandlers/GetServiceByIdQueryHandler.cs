using JadooProject.DataAccess.Context;
using JadooProject.Features.Mediator.Queries.ServiceQueries;
using JadooProject.Features.Mediator.Results.ServiceResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JadooProject.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly JadooContext _context;

        public GetServiceByIdQueryHandler(JadooContext context)
        {
            _context = context;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Services.FirstOrDefaultAsync(x=>x.ServiceId==request.Id);
            var service = new GetServiceByIdQueryResult
            {
                ServiceId=value.ServiceId,
                Description=value.Description,
                Icon=value.Icon,
                Title=value.Title,
            };
            return service; 
        }
    }
}

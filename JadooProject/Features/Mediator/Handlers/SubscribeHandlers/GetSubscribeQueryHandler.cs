using JadooProject.DataAccess.Context;
using JadooProject.Features.Mediator.Queries.SubscribeQueries;
using JadooProject.Features.Mediator.Results.SubscribeResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JadooProject.Features.Mediator.Handlers.SubscribeHandlers
{
    public class GetSubscribeQueryHandler : IRequestHandler<GetSubscribeQuery, List<GetSubscribeQueryResult>>
    {
        private readonly JadooContext _context;

        public GetSubscribeQueryHandler(JadooContext context)
        {
            _context = context;
        }

        public async Task<List<GetSubscribeQueryResult>> Handle(GetSubscribeQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Subscribes.ToListAsync();

            return values.Select(x => new GetSubscribeQueryResult
            {
                SubscribeId = x.SubscribeId,
                Email = x.Email
            }).ToList();
        }
    }
}

using JadooProject.DataAccess.Context;
using JadooProject.Features.Mediator.Queries.SubscribeQueries;
using JadooProject.Features.Mediator.Results.SubscribeResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JadooProject.Features.Mediator.Handlers.SubscribeHandlers
{
    public class GetSubscribeByIdQueryHandler : IRequestHandler<GetSubscribeByIdQuery, GetSubscribeByIdQueryResult>
    {
        private readonly JadooContext _context;

        public GetSubscribeByIdQueryHandler(JadooContext context)
        {
            _context = context;
        }

        public async Task<GetSubscribeByIdQueryResult> Handle(GetSubscribeByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Subscribes.FirstOrDefaultAsync(x => x.SubscribeId == request.Id);

            return new GetSubscribeByIdQueryResult
            {
                SubscribeId = value.SubscribeId,
                Email = value.Email
            };
        }
    }
}

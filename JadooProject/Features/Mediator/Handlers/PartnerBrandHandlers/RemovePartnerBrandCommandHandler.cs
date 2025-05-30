using JadooProject.DataAccess.Context;
using JadooProject.Features.Mediator.Commands.PartnerBrand;
using MediatR;

namespace JadooProject.Features.Mediator.Handlers.PartnerBrandHandlers
{
    public class RemovePartnerBrandCommandHandler : IRequestHandler<RemovePartnerBrandCommand>
    {
        private readonly JadooContext _context;

        public RemovePartnerBrandCommandHandler(JadooContext context)
        {
            _context = context;
        }

        public async Task Handle(RemovePartnerBrandCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.PartnerBrands.FindAsync(request.Id);
            _context.PartnerBrands.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}

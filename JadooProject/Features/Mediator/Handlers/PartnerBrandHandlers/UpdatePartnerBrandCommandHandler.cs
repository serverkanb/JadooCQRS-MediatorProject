using JadooProject.DataAccess.Context;
using JadooProject.DataAccess.Entities;
using JadooProject.Features.Mediator.Commands.PartnerBrand;
using MediatR;

namespace JadooProject.Features.Mediator.Handlers.PartnerBrandHandlers
{
    public class UpdatePartnerBrandCommandHandler : IRequestHandler<UpdatePartnerBrandCommand>
    {
        private readonly JadooContext _context;

        public UpdatePartnerBrandCommandHandler(JadooContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdatePartnerBrandCommand request, CancellationToken cancellationToken)
        {
            var entity = new PartnerBrand()
            {
                PartnerBrandId = request.PartnerBrandId,
                LogoUrl = request.LogoUrl,
            };

             _context.Update(entity);
            await _context.SaveChangesAsync();
            
        }
    }
}

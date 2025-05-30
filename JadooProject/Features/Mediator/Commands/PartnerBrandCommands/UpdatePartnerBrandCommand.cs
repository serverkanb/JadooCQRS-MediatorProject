using MediatR;

namespace JadooProject.Features.Mediator.Commands.PartnerBrand
{
    public class UpdatePartnerBrandCommand : IRequest
    {
        public int PartnerBrandId { get; set; }
        public string LogoUrl { get; set; }
    }
}

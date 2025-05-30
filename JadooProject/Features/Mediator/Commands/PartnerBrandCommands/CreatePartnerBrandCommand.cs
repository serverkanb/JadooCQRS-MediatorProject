using MediatR;

namespace JadooProject.Features.Mediator.Commands.PartnerBrand
{
    public class CreatePartnerBrandCommand : IRequest
    {
        public string LogoUrl { get; set; }
    }
}

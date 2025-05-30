using MediatR;

namespace JadooProject.Features.Mediator.Commands.PartnerBrand
{
    public class RemovePartnerBrandCommand : IRequest
    {
        public int Id { get; set; }

        public RemovePartnerBrandCommand(int id)
        {
            Id = id;
        }
    }
}

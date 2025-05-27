using MediatR;

namespace JadooProject.Features.Mediator.Commands.ServiceCommands
{
    public class UpdateServiceCommand : IRequest
    {
        public int ServiceId { get; set; }

        public string Title { get; set; }

        public string Icon { get; set; }

        public string Description { get; set; }
    }
}

using MediatR;

namespace JadooProject.Features.Mediator.Commands.SubscribeCommands
{
    public class UpdateSubscribeCommand : IRequest
    {
        public int SubscribeId { get; set; }

        public string Email { get; set; }
    }
}

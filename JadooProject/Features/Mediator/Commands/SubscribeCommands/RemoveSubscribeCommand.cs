using MediatR;

namespace JadooProject.Features.Mediator.Commands.SubscribeCommands
{
    public class RemoveSubscribeCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveSubscribeCommand(int id)
        {
            Id = id;
        }
    }
}

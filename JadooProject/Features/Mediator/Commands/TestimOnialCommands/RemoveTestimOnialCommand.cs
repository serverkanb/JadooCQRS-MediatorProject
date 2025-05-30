using MediatR;

namespace JadooProject.Features.Mediator.Commands.TesstimOnialCommands
{

    public class RemoveTestimOnialCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveTestimOnialCommand(int id)
        {
            Id = id;
        }
    }

}

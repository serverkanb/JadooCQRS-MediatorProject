using MediatR;

namespace JadooProject.Features.Mediator.Commands.TesstimOnialCommands
{
    public class UpdateTestimOnialCommand : IRequest
    {
        public int TestimOnialId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
    }
}

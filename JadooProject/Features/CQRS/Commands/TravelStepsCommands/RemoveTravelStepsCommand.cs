namespace JadooProject.Features.CQRS.Commands.TravelStepsCommands
{
    public class RemoveTravelStepsCommand
    {
        public int Id { get; set; }

        public RemoveTravelStepsCommand(int id)
        {
            Id = id;
        }
    }
}

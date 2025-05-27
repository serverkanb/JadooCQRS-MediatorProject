namespace JadooProject.Features.CQRS.Commands.TravelStepsCommands
{
    public class UpdateTravelStepsCommand
    {
        public int TravelStepId { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

namespace JadooProject.Features.CQRS.Commands.FeatureCommands
{
    public class UpdateFeatureCommand
    {
        public int FeatureId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}

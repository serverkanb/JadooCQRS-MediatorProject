namespace JadooProject.Features.CQRS.Commands.FeatureCommands
{
    public class CreateFeatureCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}

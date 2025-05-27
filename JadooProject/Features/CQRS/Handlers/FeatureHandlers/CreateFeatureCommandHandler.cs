using JadooProject.DataAccess.Abstract;
using JadooProject.DataAccess.Entities;
using JadooProject.Features.CQRS.Commands.FeatureCommands;

namespace JadooProject.Features.CQRS.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler
    {
        private readonly IRepository<Feature> _repository;

        public CreateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public void Handle(CreateFeatureCommand command)
        {
            var entity = new Feature
            {
                Title = command.Title,
                Description = command.Description,
                ImageUrl = command.ImageUrl
            };

            _repository.Create(entity);
        }
    }
}

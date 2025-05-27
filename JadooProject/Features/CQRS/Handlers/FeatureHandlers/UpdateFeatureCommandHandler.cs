using JadooProject.DataAccess.Abstract;
using JadooProject.DataAccess.Entities;
using JadooProject.Features.CQRS.Commands.FeatureCommands;

namespace JadooProject.Features.CQRS.Handlers.FeatureHandlers
{
    public class UpdateFeatureCommandHandler
    {
        private readonly IRepository<Feature> _repository;

        public UpdateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public void Handle(UpdateFeatureCommand command)
        {
            var entity = _repository.GetById(command.FeatureId);
            if (entity == null) return;

            entity.Title = command.Title;
            entity.Description = command.Description;
            entity.ImageUrl = command.ImageUrl;

            _repository.Update(entity);
        }
    }
}

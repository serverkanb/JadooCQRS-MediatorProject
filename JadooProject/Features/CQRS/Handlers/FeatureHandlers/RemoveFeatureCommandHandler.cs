using JadooProject.DataAccess.Abstract;
using JadooProject.DataAccess.Entities;
using JadooProject.Features.CQRS.Commands.FeatureCommands;

namespace JadooProject.Features.CQRS.Handlers.FeatureHandlers
{
    public class RemoveFeatureCommandHandler
    {
        private readonly IRepository<Feature> _repository;

        public RemoveFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public void Handle(RemoveFeatureCommand command)
        {
            var entity = _repository.GetById(command.Id);
                _repository.Delete(entity.FeatureId);
            
        }
    }
}

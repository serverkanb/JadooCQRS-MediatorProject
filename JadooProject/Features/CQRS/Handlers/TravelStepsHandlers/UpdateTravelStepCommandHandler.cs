using JadooProject.DataAccess.Abstract;
using JadooProject.DataAccess.Entities;
using JadooProject.Features.CQRS.Commands.TravelStepsCommands;

namespace JadooProject.Features.CQRS.Handlers.TravelStepsHandlers
{
    public class UpdateTravelStepCommandHandler
    {
        private readonly IRepository<TravelStep> _repository;

        public UpdateTravelStepCommandHandler(IRepository<TravelStep> repository)
        {
            _repository = repository;
        }

        public void Handle(UpdateTravelStepsCommand command)
        {
            var entity = _repository.GetById(command.TravelStepId);
            if (entity == null) return;

            entity.Icon = command.Icon;
            entity.Title = command.Title;
            entity.Description = command.Description;

            _repository.Update(entity);
        }
    }
}

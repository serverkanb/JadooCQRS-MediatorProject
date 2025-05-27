using JadooProject.DataAccess.Abstract;
using JadooProject.DataAccess.Entities;
using JadooProject.Features.CQRS.Commands.TravelStepsCommands;

namespace JadooProject.Features.CQRS.Handlers.TravelStepsHandlers
{
    public class RemoveTravelStepCommandHandler
    {
        private readonly IRepository<TravelStep> _repository;

        public RemoveTravelStepCommandHandler(IRepository<TravelStep> repository)
        {
            _repository = repository;
        }

        public void Handle(RemoveTravelStepsCommand command)
        {
            var entity = _repository.GetById(command.Id);
            if (entity != null)
            {
                _repository.Delete(entity.TravelStepId);
            }
        }
    }
}

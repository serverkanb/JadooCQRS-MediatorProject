using JadooProject.DataAccess.Abstract;
using JadooProject.DataAccess.Entities;
using JadooProject.Features.CQRS.Commands.TravelStep;

namespace JadooProject.Features.CQRS.Handlers.TravelStepsHandlers
{
    public class CreateTravelStepCommandHandler
    {
        private readonly IRepository<TravelStep> _repository;

        public CreateTravelStepCommandHandler(IRepository<TravelStep> repository)
        {
            _repository = repository;
        }

        public void Handle(CreateTravelStepCommand command)
        {
            var entity = new TravelStep
            {
                Icon = command.Icon,
                Title = command.Title,
                Description = command.Description
            };
            _repository.Create(entity);
        }
    }
}

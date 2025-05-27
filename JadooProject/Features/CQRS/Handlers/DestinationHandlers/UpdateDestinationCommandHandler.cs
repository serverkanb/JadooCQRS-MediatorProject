using JadooProject.DataAccess.Abstract;
using JadooProject.DataAccess.Entities;
using JadooProject.Features.CQRS.Commands.DestinationCommands;

namespace JadooProject.Features.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly IRepository<Destination> _repository;

        public UpdateDestinationCommandHandler(IRepository<Destination> repository)
        {
            _repository = repository;
        }

        public void Handle(UpdateDestinationCommand command)
        {
            var destination = new Destination
            {
                City = command.City,
                DestinationId = command.DestinationId,
                Duration = command.Duration,
                ImageUrl = command.ImageUrl,
                Price = command.Price
            };

            _repository.Update(destination);
        }
    }
}

using JadooProject.DataAccess.Abstract;
using JadooProject.DataAccess.Entities;
using JadooProject.Features.CQRS.Queries.TravelStepQueries;
using JadooProject.Features.CQRS.Results.TravelStepResults;

namespace JadooProject.Features.CQRS.Handlers.TravelStepsHandlers
{
    public class GetTravelStepByIdQueryHandler
    {
        private readonly IRepository<TravelStep> _repository;

        public GetTravelStepByIdQueryHandler(IRepository<TravelStep> repository)
        {
            _repository = repository;
        }

        public GetTravelStepByIdQueryResult Handle(GetTravelStepByIdQuery query)
        {
            var entity = _repository.GetById(query.Id);
        

            return new GetTravelStepByIdQueryResult
            {
                TravelStepId = entity.TravelStepId,
                Icon = entity.Icon,
                Title = entity.Title,
                Description = entity.Description
            };
        }
    }
}

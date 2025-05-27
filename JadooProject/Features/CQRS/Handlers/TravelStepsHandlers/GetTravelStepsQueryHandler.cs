using JadooProject.DataAccess.Abstract;
using JadooProject.DataAccess.Entities;
using JadooProject.Features.CQRS.Results.TravelStepResults;

namespace JadooProject.Features.CQRS.Handlers.TravelStepsHandlers
{
    public class GetTravelStepsQueryHandler
    {
        private readonly IRepository<TravelStep> _repository;

        public GetTravelStepsQueryHandler(IRepository<TravelStep> repository)
        {
            _repository = repository;
        }

        public List<GetTravelStepsQueryResult> Handle()
        {
            return _repository.GetList()
                .Select(x => new GetTravelStepsQueryResult
                {
                    TravelStepId = x.TravelStepId,
                    Icon = x.Icon,
                    Title = x.Title,
                    Description = x.Description
                }).ToList();
        }
    }
}

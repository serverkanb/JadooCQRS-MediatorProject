using JadooProject.DataAccess.Abstract;
using JadooProject.DataAccess.Entities;
using JadooProject.Features.CQRS.Queries.FeatureQueries;
using JadooProject.Features.CQRS.Results.FeatureResult;

namespace JadooProject.Features.CQRS.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureByIdQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public GetFeatureByIdQueryResult Handle(GetFeatureByIdQuery query)
        {
            var value = _repository.GetById(query.Id);
            return new GetFeatureByIdQueryResult
            {
                FeatureId = value.FeatureId,
                Title = value.Title,
                Description = value.Description,
                ImageUrl = value.ImageUrl
            };
        }
    }
}

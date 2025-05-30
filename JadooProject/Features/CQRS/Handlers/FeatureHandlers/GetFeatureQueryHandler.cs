using JadooProject.DataAccess.Abstract;
using JadooProject.DataAccess.Entities;
using JadooProject.Features.CQRS.Results.FeatureResult;

namespace JadooProject.Features.CQRS.Handlers.FeatureHandlers
{

    public class GetFeatureQueryHandler
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public List<GetFeatureQueryResult> Handle()
        {
            var values = _repository.GetList();

            return values.Select(x => new GetFeatureQueryResult
            {
                FeatureId = x.FeatureId,
                Title = x.Title,
                Description = x.Description,
                ImageUrl = x.ImageUrl
            }).ToList();
        }
    }



}

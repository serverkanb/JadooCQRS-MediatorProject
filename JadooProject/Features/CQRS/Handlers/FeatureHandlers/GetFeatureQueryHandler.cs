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

        public GetFeatureQueryResult Handle()
        {
            var value = _repository.GetList().FirstOrDefault(); // tek satır

            return new GetFeatureQueryResult
            {
                Title = value.Title,
                Description = value.Description,
                ImageUrl = value.ImageUrl
            };
        }
    }


}

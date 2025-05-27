using JadooProject.DataAccess.Abstract;
using JadooProject.DataAccess.Entities;
using JadooProject.Features.CQRS.Results.DestinationResult;

namespace JadooProject.Features.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationQueryHandler
    {
        private readonly IRepository<Destination> _repository;

        public GetDestinationQueryHandler(IRepository<Destination> repository)
        {
            _repository = repository;
        }

        public List<GetDestinationQueryResult> Handle()
        {
            var values = _repository.GetList();

            List<GetDestinationQueryResult> result = (from x in values
                                                      select new GetDestinationQueryResult
                                                      {
                                                          City = x.City,
                                                          DestinationId = x.DestinationId,
                                                          Duration = x.Duration,
                                                          ImageUrl = x.ImageUrl,
                                                          Price = x.Price
                                                      }).ToList();

            return result;

        }
    }
}

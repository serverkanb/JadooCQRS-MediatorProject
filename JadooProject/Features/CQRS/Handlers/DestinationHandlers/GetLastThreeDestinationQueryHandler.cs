using JadooProject.DataAccess.Abstract;
using JadooProject.DataAccess.Entities;
using JadooProject.Features.CQRS.Results.DestinationResult;

namespace JadooProject.Features.CQRS.Handlers.DestinationHandlers
{
    public class GetLastThreeDestinationQueryHandler
    {
        private readonly IRepository<Destination> _repository;

        public GetLastThreeDestinationQueryHandler(IRepository<Destination> repository)
        {
            _repository = repository;
        }

        public List<GetDestinationQueryResult> Handle()
        {

            return _repository.GetList()
                   .OrderByDescending(x => x.DestinationId) // Son eklenenler üstte
                   .Take(3) // Sadece 3 tanesi
                   .Select(x => new GetDestinationQueryResult
                   {
                       City = x.City,
                       DestinationId = x.DestinationId,
                       Duration = x.Duration,
                       ImageUrl = x.ImageUrl,
                       Price = x.Price
                   })
                   .ToList(); // Listeye çevir

        }
    }
}


using JadooProject.DataAccess.Context;
using JadooProject.Features.CQRS.Results.DestinationResult;
using Microsoft.AspNetCore.Mvc;

namespace JadooProject.ViewComponents.Destination
{
    public class DestinationViewComponent : ViewComponent
    {
        private readonly JadooContext _context;

        public DestinationViewComponent(JadooContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Destinations.OrderBy(x => x.DestinationId)
            .Take(3). Select(x => new GetDestinationQueryResult
            {
                DestinationId = x.DestinationId,
                City = x.City,
                Duration = x.Duration,
                ImageUrl = x.ImageUrl,
                Price = x.Price
            }).ToList();

            return View(values);
        }
    }
}

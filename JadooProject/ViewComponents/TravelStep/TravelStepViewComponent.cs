using JadooProject.DataAccess.Context;
using JadooProject.Features.CQRS.Results.TravelStepResults;
using Microsoft.AspNetCore.Mvc;

namespace JadooProject.ViewComponents.TravelStep
{
    public class TravelStepViewComponent : ViewComponent
    {
        private readonly JadooContext _context;

        public TravelStepViewComponent(JadooContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var travelStep = _context.TravelSteps.Select(x => new GetTravelStepsQueryResult
            {
                TravelStepId = x.TravelStepId,
                Title = x.Title,
                Description = x.Description,
                Icon = x.Icon
            }).ToList();

            var lastTour = _context.Destinations
            .OrderByDescending(x => x.DestinationId)
            .FirstOrDefault();

            ViewBag.LastTourCity = lastTour?.City;
            ViewBag.LastTourImage = lastTour?.ImageUrl;
            return View(travelStep);
        }
    }
}

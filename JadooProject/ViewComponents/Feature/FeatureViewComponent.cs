using JadooProject.DataAccess.Context;
using JadooProject.Features.CQRS.Results.FeatureResult;
using Microsoft.AspNetCore.Mvc;

namespace JadooProject.ViewComponents.Feature
{
    public class FeatureViewComponent : ViewComponent
    {
        private readonly JadooContext _context;

        public FeatureViewComponent(JadooContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Features.Select(x => new GetFeatureQueryResult
            {
                FeatureId = x.FeatureId,
                Description = x.Description,
               Title = x.Title,
               ImageUrl = x.ImageUrl,
               
               
            }).ToList();

            return View(values);
        }
    }
}

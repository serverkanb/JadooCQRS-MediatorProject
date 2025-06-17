using JadooProject.DataAccess.Context;
using JadooProject.Features.Mediator.Results.PartnerBrandResults;
using Microsoft.AspNetCore.Mvc;

namespace JadooProject.ViewComponents.PartnerBrand
{
    public class PartnerBrandViewComponent : ViewComponent
    {
        private readonly JadooContext _context;

        public PartnerBrandViewComponent(JadooContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.PartnerBrands.Select(x => new GetPartnerBrandQueryResult
            {
                PartnerBrandId = x.PartnerBrandId,
               LogoUrl = x.LogoUrl
            }).ToList();

            return View(values);
        }
    }
}

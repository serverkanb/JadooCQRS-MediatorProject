using JadooProject.DataAccess.Context;
using JadooProject.Features.Mediator.Results.TestimOnialResults;
using Microsoft.AspNetCore.Mvc;

namespace JadooProject.ViewComponents.TestimOnial
{
    public class TestimonialViewComponent : ViewComponent
    {
        private readonly JadooContext _context;

        public TestimonialViewComponent(JadooContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.TestimOnials.Select(x => new GetTestimOnialQueryResult
            {
                TestimonialId = x.TestimonialId,
                Name = x.Name,
                Comment = x.Comment,
                ImageUrl = x.ImageUrl,
                Location = x.Location
            }).ToList();

            return View(values);
        }
    }
}

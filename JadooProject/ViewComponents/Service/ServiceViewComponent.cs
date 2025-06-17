using JadooProject.DataAccess.Context;
using JadooProject.Features.Mediator.Results.ServiceResults;
using Microsoft.AspNetCore.Mvc;

namespace JadooProject.ViewComponents.Service
{
    public class ServiceViewComponent : ViewComponent
    {
        private readonly JadooContext _context;

        public ServiceViewComponent(JadooContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Services.Select(x => new GetServiceQueryResult
            {
                ServiceId = x.ServiceId,
                Title = x.Title,
                Description = x.Description,
                Icon = x.Icon,
                
            }).ToList();

            return View(values);
        }
    }
}

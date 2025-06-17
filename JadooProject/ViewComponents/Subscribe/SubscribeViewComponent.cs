using JadooProject.DataAccess.Context;
using JadooProject.DataAccess.Entities;
using JadooProject.Features.Mediator.Results.SubscribeResults;
using Microsoft.AspNetCore.Mvc;

namespace JadooProject.ViewComponents.Subscribe
{
    public class SubscribeViewComponent : ViewComponent
    {
        private readonly JadooContext _context;

        public SubscribeViewComponent(JadooContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
    

            return View();
        
        }

        
    }
}

using JadooProject.DataAccess.Context;
using JadooProject.Features.CQRS.Handlers.DestinationHandlers;
using JadooProject.Features.CQRS.Queries.DestinationQueries;
using Microsoft.AspNetCore.Mvc;

namespace JadooProject.Controllers
{
    public class AllDestinationController : Controller
    {
        private readonly GetDestinationByIdQueryHandler _getDestinationByIdQueryHandler;
      private readonly GetDestinationQueryHandler _getDestinationQueryhandler;

        public AllDestinationController(GetDestinationQueryHandler getDestinationQueryhandler, GetDestinationByIdQueryHandler getDestinationByIdQueryHandler)
        {
            _getDestinationQueryhandler = getDestinationQueryhandler;
            _getDestinationByIdQueryHandler = getDestinationByIdQueryHandler;
        }

        public IActionResult Index()
        {
            var values = _getDestinationQueryhandler.Handle();
            return View(values);
        }
        public IActionResult Detail(int id)
        {
            var value = _getDestinationByIdQueryHandler.Handle(new GetDestinationByIdQuery(id));
            if (value == null)
            {
                return NotFound();
            }
            return View(value);
        }
    }
}

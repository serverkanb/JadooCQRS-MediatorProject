using JadooProject.Features.CQRS.Commands.TravelStep;
using JadooProject.Features.CQRS.Commands.TravelStepsCommands;
using JadooProject.Features.CQRS.Handlers.TravelStepsHandlers;
using JadooProject.Features.CQRS.Queries.TravelStepQueries;
using Microsoft.AspNetCore.Mvc;

namespace JadooProject.Controllers
{
    public class TravelStepController : Controller
    {
        private readonly GetTravelStepsQueryHandler _getTravelStepsQueryHandler;
        private readonly CreateTravelStepCommandHandler _createTravelStepCommandHandler;
        private readonly UpdateTravelStepCommandHandler _updateTravelStepCommanHandler;
        private readonly RemoveTravelStepCommandHandler _removeTravelStepCommanHandler;
        private readonly GetTravelStepByIdQueryHandler _getTravelStepByIdQueryHandler;

        public TravelStepController(GetTravelStepsQueryHandler getTravelStepsQueryHandler, CreateTravelStepCommandHandler createTravelStepCommandHandler, UpdateTravelStepCommandHandler updateTravelStepCommandHandler, RemoveTravelStepCommandHandler removeTravelStepCommandHandler, GetTravelStepByIdQueryHandler getTravelStepCommandByIdQueryHandler)
        {
            _getTravelStepsQueryHandler = getTravelStepsQueryHandler;
            _createTravelStepCommandHandler = createTravelStepCommandHandler;
            _updateTravelStepCommanHandler = updateTravelStepCommandHandler;
            _removeTravelStepCommanHandler = removeTravelStepCommandHandler;
            _getTravelStepByIdQueryHandler = getTravelStepCommandByIdQueryHandler;
        }

        public IActionResult Index()
        {
            var values = _getTravelStepsQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateTravelStepCommand command)
        {
            _createTravelStepCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _getTravelStepByIdQueryHandler.Handle(new GetTravelStepByIdQuery(id));

            var model = new UpdateTravelStepsCommand
            {
                TravelStepId = value.TravelStepId,
                Title = value.Title,
                Icon = value.Icon,
                Description = value.Description
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(UpdateTravelStepsCommand command)
        {
            _updateTravelStepCommanHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _removeTravelStepCommanHandler.Handle(new RemoveTravelStepsCommand(id));
            return RedirectToAction("Index");
        }
    }
}

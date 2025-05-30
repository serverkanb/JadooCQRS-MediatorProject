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
        private readonly UpdateTravelStepCommandHandler _updateTravelStepCommandHandler;
        private readonly RemoveTravelStepCommandHandler _removeTravelStepCommandHandler;
        private readonly GetTravelStepByIdQueryHandler _getTravelStepByIdQueryHandler;

        public TravelStepController(
            GetTravelStepsQueryHandler getTravelStepsQueryHandler,
            CreateTravelStepCommandHandler createTravelStepCommandHandler,
            UpdateTravelStepCommandHandler updateTravelStepCommandHandler,
            RemoveTravelStepCommandHandler removeTravelStepCommandHandler,
            GetTravelStepByIdQueryHandler getTravelStepByIdQueryHandler)
        {
            _getTravelStepsQueryHandler = getTravelStepsQueryHandler;
            _createTravelStepCommandHandler = createTravelStepCommandHandler;
            _updateTravelStepCommandHandler = updateTravelStepCommandHandler;
            _removeTravelStepCommandHandler = removeTravelStepCommandHandler;
            _getTravelStepByIdQueryHandler = getTravelStepByIdQueryHandler;
        }

        public IActionResult Index()
        {
            var values = _getTravelStepsQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTravelStep()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTravelStep(CreateTravelStepCommand command)
        {
            _createTravelStepCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateTravelStep(int id)
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
        public IActionResult UpdateTravelStep(UpdateTravelStepsCommand command)
        {
            _updateTravelStepCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTravelStep(int id)
        {
            _removeTravelStepCommandHandler.Handle(new RemoveTravelStepsCommand(id));
            return RedirectToAction("Index");
        }
    }
}

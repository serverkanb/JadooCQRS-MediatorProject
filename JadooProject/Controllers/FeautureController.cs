using JadooProject.DataAccess.Abstract;
using JadooProject.DataAccess.Entities;
using JadooProject.Features.CQRS.Commands.FeatureCommands;
using JadooProject.Features.CQRS.Handlers.FeatureHandlers;
using JadooProject.Features.CQRS.Queries.FeatureQueries;
using Microsoft.AspNetCore.Mvc;

namespace JadooProject.Controllers
{
    public class FeatureController : Controller
    {
        private readonly GetFeatureQueryHandler _getFeatureQueryHandler;
        private readonly GetFeatureByIdQueryHandler _getFeatureByIdQueryHandler;
        private readonly CreateFeatureCommandHandler _createFeatureCommandHandler;
        private readonly RemoveFeatureCommandHandler _removeFeatureCommandHandler;
        private readonly UpdateFeatureCommandHandler _updateFeatureCommandHandler;

        public FeatureController(
            GetFeatureQueryHandler getFeatureQueryHandler,
            GetFeatureByIdQueryHandler getFeatureByIdQueryHandler,
            CreateFeatureCommandHandler createFeatureCommandHandler,
            RemoveFeatureCommandHandler removeFeatureCommandHandler,
            UpdateFeatureCommandHandler updateFeatureCommandHandler)
        {
            _getFeatureQueryHandler = getFeatureQueryHandler;
            _getFeatureByIdQueryHandler = getFeatureByIdQueryHandler;
            _createFeatureCommandHandler = createFeatureCommandHandler;
            _removeFeatureCommandHandler = removeFeatureCommandHandler;
            _updateFeatureCommandHandler = updateFeatureCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _getFeatureQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult UpdateFeature(int id)
        {
            var value = _getFeatureByIdQueryHandler.Handle(new GetFeatureByIdQuery(id));

            var model = new UpdateFeatureCommand
            {
                FeatureId = value.FeatureId,
                Title = value.Title,
                Description = value.Description,
                ImageUrl = value.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateFeature(UpdateFeatureCommand command)
        {
            _updateFeatureCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureCommand command)
        {
            _createFeatureCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFeature(int id)
        {
            _removeFeatureCommandHandler.Handle(new RemoveFeatureCommand(id));
            return RedirectToAction("Index");
        }
    }



}

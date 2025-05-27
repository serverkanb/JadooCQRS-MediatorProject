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
        private readonly CreateFeatureCommandHandler _createFeatureCommandHandler;
        private readonly UpdateFeatureCommandHandler _updateFeatureCommandHandler;
        private readonly RemoveFeatureCommandHandler _removeFeatureCommandHandler;
        private readonly GetFeatureByIdQueryHandler _getFeatureByIdQueryHandler;
        private readonly GetFeatureQueryHandler _getFeatureQueryHandler;

        public FeatureController(
            CreateFeatureCommandHandler createHandler,
            UpdateFeatureCommandHandler updateHandler,
            RemoveFeatureCommandHandler removeHandler,
            GetFeatureByIdQueryHandler getByIdHandler,
            GetFeatureQueryHandler getAllHandler)
        {
            _createFeatureCommandHandler = createHandler;
            _updateFeatureCommandHandler = updateHandler;
            _removeFeatureCommandHandler = removeHandler;
            _getFeatureByIdQueryHandler = getByIdHandler;
            _getFeatureQueryHandler = getAllHandler;
        }

        public IActionResult Index()
        {
            var values = _getFeatureQueryHandler.Handle(); // Eğer tek satır ise FirstOrDefault() kullan
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateFeatureCommand command)
        {
            _createFeatureCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
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
        public IActionResult Update(UpdateFeatureCommand command)
        {
            _updateFeatureCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _removeFeatureCommandHandler.Handle(new RemoveFeatureCommand(id));
            return RedirectToAction("Index");
        }
    }


}

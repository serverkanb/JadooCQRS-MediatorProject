using JadooProject.Features.Mediator.Commands.ServiceCommands;
using JadooProject.Features.Mediator.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooProject.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetServiceQuery());

            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var value = await _mediator.Send(new GetServiceByIdQuery(id));
            var service = new UpdateServiceCommand()
            {
                ServiceId = value.ServiceId,
                Description = value.Description,
                Title = value.Title,
                Icon = value.Icon
            };
            return View(service); 
        }
        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            await _mediator.Send(new RemoveServiceCommand(id));
            return RedirectToAction("Index");
        }
    }
}

using JadooProject.Features.Mediator.Commands.SubscribeCommands;
using JadooProject.Features.Mediator.Queries.SubscribeQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JadooProject.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly IMediator _mediator;

        public SubscribeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetSubscribeQuery());
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSubscriber()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscriber(CreateSubscribeCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        
        [HttpGet]
        public async Task<IActionResult> UpdateSubscriber(int id)
        {
            var value = await _mediator.Send(new GetSubscribeByIdQuery(id));
            var model = new UpdateSubscribeCommand
            {
                SubscribeId = value.SubscribeId,
                Email = value.Email
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubscriber(UpdateSubscribeCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteSubscriber(int id)
        {
            await _mediator.Send(new RemoveSubscribeCommand(id));
            return RedirectToAction("Index");
        }
    }
}

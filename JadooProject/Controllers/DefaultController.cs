using JadooProject.Features.Mediator.Commands.SubscribeCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JadooProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IMediator _mediator;

        public DefaultController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Subscribe(CreateSubscribeCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                TempData["SubscribeMessage"] = "Teşekkürler, başarıyla abone oldunuz!";
                return RedirectToAction("Index");
            }

            TempData["SubscribeMessage"] = "Bir hata oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("Index");
        }
    }
}

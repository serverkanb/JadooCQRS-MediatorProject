using JadooProject.DataAccess.Entities;
using JadooProject.Features.Mediator.Commands.PartnerBrand;
using JadooProject.Features.Mediator.Queries.PartnerBrandQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JadooProject.Controllers
{
    public class PartnerBrandController : Controller
    {
        private readonly IMediator _mediator;

        public PartnerBrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetPartnerBrandQuery());
            return View(values);
        }

        [HttpGet]
        public IActionResult CreatePartner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePartner(CreatePartnerBrandCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePartner(int id)
        {
            var values = await _mediator.Send(new GetPartnerBrandByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePartner(UpdatePartnerBrandCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletePartner(int id)
        {
            await _mediator.Send(new RemovePartnerBrandCommand(id));
            return RedirectToAction("Index");
        }
    }
}


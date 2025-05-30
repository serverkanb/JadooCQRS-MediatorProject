using JadooProject.Features.Mediator.Commands.TesstimOnialCommands;
using JadooProject.Features.Mediator.Queries.TestimOnialQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JadooProject.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IMediator _mediator;

        public TestimonialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetTestimonialQuery());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var value = await _mediator.Send(new GetTestimonialByIdQuery(id));

            var testimonial = new UpdateTestimOnialCommand
            {
                TestimOnialId = value.TestimonialId,
                Name = value.Name,
                Location = value.Location,
                Comment = value.Comment,
                ImageUrl = value.ImageUrl
            };

            return View(testimonial);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimOnialCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimOnialCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _mediator.Send(new RemoveTestimOnialCommand(id));
            return RedirectToAction("Index");
        }
    }
}

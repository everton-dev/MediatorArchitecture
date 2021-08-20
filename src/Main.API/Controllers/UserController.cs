using Domain.Models.Commands.Requests;
using Domain.Models.Commands.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Main.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(UserCreateCommand request)
        {
            var result = await _mediator.Send(request, CancellationToken.None);
            return await ValidationHandler(result);
        }

        [NonAction]
        public async Task<IActionResult> ValidationHandler(UserResponse result)
        {
            if (!result.HasValidations)
                return await Task.Run(() => Ok(result));

            foreach (var validation in result.Validations)
                ModelState.AddModelError("", validation);

            return await Task.Run(() => BadRequest(result));
        }
    }
}
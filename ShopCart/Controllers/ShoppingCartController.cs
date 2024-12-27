using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopCart.Application.Commands;
using ShopCart.Application.Extensions;
using ShopCart.Application.Queries;

namespace ShopCart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ILogger<ShoppingCartController> _logger;
        private readonly IMediator _mediator;
        private readonly IValidator<AddItemCommand> _validator;

        public ShoppingCartController(ILogger<ShoppingCartController> logger, IMediator mediator, IValidator<AddItemCommand> validator)
        {
            _logger = logger;
            _mediator = mediator;
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddItemCommand command)
        {
            var personValidator = await _validator.ValidateAsync(command);
            if (!personValidator.IsValid)
            {
                personValidator.AddToModelState(ModelState);
                return UnprocessableEntity(ModelState);
            }
            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetCart(string userId)
        {
            try
            {
                return Ok(await _mediator.Send(new GetShoppingCartQuery(userId)));
            }
            catch (Exception)
            {

                return BadRequest("The user ID not exists!");
            }
        }
    }
}

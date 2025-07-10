using FoodCart.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodCart.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodCartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly ILogger<FoodCartController> _logger;

        public FoodCartController(ICartService cartService, ILogger<FoodCartController> logger)
        {
            _cartService = cartService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult GetCart()
        {
            return Ok(_cartService.GetCart());
        }

        [HttpPost]
        public IActionResult AddItem([FromBody] AddToCartRequest request)
        {
            _cartService.AddItemToCart(request.ProductId, request.Quantity);

            return Ok();
        }

        public record AddToCartRequest(Guid ProductId, int Quantity);
    }
}
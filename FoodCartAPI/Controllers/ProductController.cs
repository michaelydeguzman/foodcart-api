using FoodCart.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodCart.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<FoodCartController> _logger;

        public ProductController(IProductService productService, ILogger<FoodCartController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult GetProducts()
        {
            return Ok(_productService.GetProducts());
        }
    }
}
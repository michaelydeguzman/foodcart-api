using FoodCart.Application.Interfaces;
using FoodCart.Domain.Entities;
using FoodCart.Domain.Repositories;

namespace FoodCart.Application
{
    public class CartService : ICartService
    {
        private readonly IProductRepository _productRepo;
        private readonly ICartRepository _cartRepo;

        public CartService(IProductRepository productRepo, ICartRepository cartRepo)
        {
            _productRepo = productRepo;
            _cartRepo = cartRepo;
        }

        public Cart GetCart() => _cartRepo.GetCart();

        public void AddItemToCart(Guid productId, int quantity)
        {
            var product = _productRepo.GetById(productId);
            var cart = _cartRepo.GetCart();

            cart.AddItem(product, quantity);

            _cartRepo.Save(cart);
        }
    }
}
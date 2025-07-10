using FoodCart.Domain.Entities;

namespace FoodCart.Application.Interfaces
{
    public interface ICartService
    {
        Cart GetCart();

        void AddItemToCart(Guid productId, int quantity);
    }
}

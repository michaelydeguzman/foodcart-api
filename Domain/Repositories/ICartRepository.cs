using FoodCart.Domain.Entities;

namespace FoodCart.Domain.Repositories
{
    public interface ICartRepository
    {
        Cart GetCart();       
        void Save(Cart cart);
    }
}

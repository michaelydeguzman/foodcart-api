using FoodCart.Domain.Entities;

namespace FoodCart.Application.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}

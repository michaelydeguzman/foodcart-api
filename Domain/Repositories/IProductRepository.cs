using FoodCart.Domain.Entities;

namespace FoodCart.Domain.Repositories
{
    public interface IProductRepository
    {
        Product GetById(Guid id);
        IEnumerable<Product> GetAll();
    }
}

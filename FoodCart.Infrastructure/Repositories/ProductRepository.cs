using FoodCart.Domain.Entities;
using FoodCart.Domain.Repositories;
using FoodCart.Infrastructure.Data;

namespace FoodCart.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly FoodCartContext _context;
        public ProductRepository(FoodCartContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll() => _context.Products;

        public Product GetById(Guid id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
                throw new Exception($"Product Id {id} not found.");

            return product;
        }
    }
}

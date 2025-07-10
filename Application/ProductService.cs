using FoodCart.Application.Interfaces;
using FoodCart.Domain.Entities;
using FoodCart.Domain.Repositories;

namespace FoodCart.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public List<Product> GetProducts() => _productRepo.GetAll().ToList();
    }
}

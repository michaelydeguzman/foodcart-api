using FoodCart.Application;
using FoodCart.Domain.Entities;
using FoodCart.Domain.Repositories;
using Moq;
using Xunit;

namespace FoodCart.Tests
{
    public class CartServiceTests
    {

        public CartServiceTests(IProductRepository productRepo, ICartRepository cartRepo) { }

        [Fact]
        public void AddItemToCart_AddsProductSuccessfully()
        {
            var product = new Product(Guid.NewGuid(), "Test", 10m);

            var mockProductRepo = new Mock<IProductRepository>();
            var mockCartRepo = new Mock<ICartRepository>();

            var cart = new Cart();

            mockProductRepo.Setup(p=>p.GetById(product.Id)).Returns(product);
            mockCartRepo.Setup(r => r.GetCart()).Returns(cart);

            var service = new CartService(mockProductRepo.Object, mockCartRepo.Object);
            service.AddItemToCart(product.Id, 2);

            Assert.Equal(1, cart.Items.Count);
            Assert.Equal(20m, cart.Total);
        }
    }
}
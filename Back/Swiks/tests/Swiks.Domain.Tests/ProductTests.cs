using Moq;
using Swiks.Domain.Entities;
using Swiks.Domain.Interfaces.Repository;
using Swiks.Domain.Services;
using Swiks.Domain.Tests.Fixture;
using Xunit;

namespace Swiks.Domain.Tests
{
    [Collection(nameof(ProductCollection))]
    public class ProductTests
    {
        private readonly ProductTestsFixture _productTestsFixture;
        public ProductTests(ProductTestsFixture productTestsFixture)
        {
            _productTestsFixture = productTestsFixture;
        }

        [Fact(DisplayName = "Insert a new Product valid")]
        [Trait("Product", "Product Fixture Tests")]
        public void Product_Insert_IsValid()
        {
            //Arrange
            var product = _productTestsFixture.ProductValid();
            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(x => x.Insert(It.IsAny<Product>())).Returns(product);
            var productServices = new ProductServices(productRepository.Object);

            //Act
            var result = productServices.Insert(product);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(0, product.ValidationResult.Errors.Count);
            productRepository.Verify(x => x.Insert(product), Times.Once);
        }
    }
}

using Swiks.Domain.Entities;
using System;
using Xunit;

namespace Swiks.Domain.Tests.Fixture
{
    [CollectionDefinition(nameof(ProductCollection))]
    public class ProductCollection : ICollectionFixture<ProductTestsFixture> { }

    public class ProductTestsFixture : IDisposable
    {
        public Product ProductValid() => new Product("Hope", "Its a hope with 20m", 21, 0);
        public Product ProductNotValid() => new Product(null, "Its a hope with 20m", 0, 0);
        public void Dispose(){}
    }
}

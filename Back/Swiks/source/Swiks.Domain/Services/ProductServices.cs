using System.Collections.Generic;
using System.Linq;
using Swiks.Domain.Entities;
using Swiks.Domain.Interfaces.Repository;
using Swiks.Domain.Interfaces.Services;

namespace Swiks.Domain.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ICollection<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product Insert(Product product)
        {
            if (ProductIsNotValid(product)) return product;
            return _productRepository.Insert(product);
        }

        private bool ProductIsNotValid(Product product)
        {
            product.ValidationResult = new ProductValidator().Validate(product);
            return product.ValidationResult.Errors.Any();
        }
    }
}

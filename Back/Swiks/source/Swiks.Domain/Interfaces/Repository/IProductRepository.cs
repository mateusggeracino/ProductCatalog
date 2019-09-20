using Swiks.Domain.Entities;
using System.Collections.Generic;

namespace Swiks.Domain.Interfaces.Repository
{
    public interface IProductRepository
    {
        Product Insert(Product product);
        ICollection<Product> GetAll();
    }
}

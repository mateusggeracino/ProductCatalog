using Swiks.Domain.Entities;
using System.Collections.Generic;

namespace Swiks.Domain.Interfaces.Services
{
    public interface IProductServices
    {
        Product Insert(Product product);
        ICollection<Product> GetAll();
    }
}

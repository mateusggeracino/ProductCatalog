using System.Collections.Generic;
using Swiks.Domain.Entities;
using Swiks.Domain.Interfaces.Repository;

namespace Swiks.Repository.Repository
{
    public class ProductRepository : IProductRepository
    {
        private static IList<Product> _data;
        private object _asyncObj = new object();

        public ProductRepository()
        {
            DataSingleton();
        }

        private void DataSingleton()
        {
            if (_data == null)
            {
                lock (_asyncObj)
                {
                    if (_data == null)
                        _data = new List<Product>();
                }
            }
        }

        public ICollection<Product> GetAll()
        {
            return _data;
        }

        public Product Insert(Product product)
        {
            _data.Add(product);
            return product;
        }
    }
}

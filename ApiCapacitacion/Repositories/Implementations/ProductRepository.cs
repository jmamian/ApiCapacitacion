using ApiCapacitacion.Models;
using ApiCapacitacion.Repositories.Interfaces;
using System.Collections.Concurrent;
namespace ApiCapacitacion.Repositories.Implementations
{
    public class ProductRepository: IProductRepository
    {
        private readonly ConcurrentDictionary<int, Product> _products = new ConcurrentDictionary<int, Product>();
        private int _currentId = 1;

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult(_products.Values.AsEnumerable());
        }

        public Task<Product> GetByIdAsync(int id)
        {
            _products.TryGetValue(id, out var product);
            return Task.FromResult(product);
        }

        public Task AddAsync(Product product)
        {
            product.Id = _currentId++;
            _products[product.Id] = product;
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Product product)
        {
            _products[product.Id] = product;
            return Task.FromResult(product);
        }


        public Task DeleteAsync(int id)
        {
            _products.TryRemove(id, out _);
            return Task.CompletedTask;
        }
    }
}

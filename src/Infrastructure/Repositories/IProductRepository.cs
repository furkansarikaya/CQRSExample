using Domain.Entities;

namespace Infrastructure.Repositories;

public interface IProductRepository
{
    Task AddProductAsync(Product product);
    Task<Product> GetProductByIdAsync(int id);
}
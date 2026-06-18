using ApiProdutos.Domain.Entities;
using ApiProdutos.Application.Dtos;

namespace ApiProdutos.Application.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Product> CreateAsync(Product product);
    Task<bool> UpdateAsync(Product product);
    Task<bool> DeleteAsync(int id);
    Task<List<ProductResponseDto>> GetProductsWithDapperAsync();
}

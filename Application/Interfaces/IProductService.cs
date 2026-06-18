using ApiProdutos.Domain.Entities;
using ApiProdutos.Application.Dtos;

namespace ApiProdutos.Application.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetAllAsync();

    Task<Product?> GetByIdAsync(int id);

    Task<Product> CreateAsync(Product product);

    Task<bool> UpdateAsync(int id, Product product);

    Task<bool> DeleteAsync(int id);
    Task<List<ProductResponseDto>> GetProductsWithDapperAsync();
}

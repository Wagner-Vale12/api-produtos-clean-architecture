using ApiProdutos.Domain.Entities;
using ApiProdutos.Application.Interfaces;
using ApiProdutos.Application.Dtos;

namespace ApiProdutos.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Product> CreateAsync(Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Name))
            throw new ArgumentException("O nome do produto é obrigatório.");

        if (product.Price <= 0)
            throw new ArgumentException("O preço do produto deve ser maior que zero.");

        if (product.Stock < 0)
            throw new ArgumentException("O estoque não pode ser negativo.");

        return await _repository.CreateAsync(product);
    }

    public async Task<bool> UpdateAsync(int id, Product product)
    {
        var existingProduct = await _repository.GetByIdAsync(id);

        if (existingProduct is null)
            return false;

        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.Stock = product.Stock;

        return await _repository.UpdateAsync(existingProduct);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<List<ProductResponseDto>> GetProductsWithDapperAsync()
    {
        return await _repository.GetProductsWithDapperAsync();
    }
}

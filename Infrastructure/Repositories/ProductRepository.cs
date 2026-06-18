using ApiProdutos.Data;
using ApiProdutos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ApiProdutos.Application.Dtos;
using ApiProdutos.Application.Interfaces;
using Dapper;
using Npgsql;
using Microsoft.Extensions.Configuration;

namespace ApiProdutos.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    private readonly IConfiguration _configuration;

    public ProductRepository(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products
        .Include(p => p.Category)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products
        .Include(p => p.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product> CreateAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<bool> UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product is null)
            return false;

        _context.Products.Remove(product);
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<List<ProductResponseDto>> GetProductsWithCategoryAsync()
    {
        return await (
            from p in _context.Products
            join c in _context.Categories
                on p.CategoryId equals c.Id
            select new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryName = c.Name
            }
        )
        .AsNoTracking()
        .ToListAsync();
    }

    public async Task<List<ProductResponseDto>> GetProductsWithDapperAsync()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        await using var connection = new NpgsqlConnection(connectionString);

        var sql = @"
        SELECT 
            p.""Id"",
            p.""Name"",
            p.""Price"",
            c.""Name"" AS ""CategoryName""
        FROM ""Products"" p
        INNER JOIN ""Categories"" c ON p.""CategoryId"" = c.""Id"";
    ";

        var result = await connection.QueryAsync<ProductResponseDto>(sql);

        return result.ToList();
    }
}

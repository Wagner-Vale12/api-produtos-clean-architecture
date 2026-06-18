using ApiProdutos.Domain.Entities;
using ApiProdutos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _service.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _service.GetByIdAsync(id);

        if (product is null)
            return NotFound("Produto não encontrado.");

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        try
        {
            var createdProduct = await _service.CreateAsync(product);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdProduct.Id },
                createdProduct
            );
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Product product)
    {
        var updated = await _service.UpdateAsync(id, product);

        if (!updated)
            return NotFound("Produto não encontrado.");

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
            return NotFound("Produto não encontrado.");

        return NoContent();
    }
    [HttpGet("report")]
    [HttpGet("dapper")]
    public async Task<IActionResult> GetProductsWithDapper()
    {
        var result = await _service.GetProductsWithDapperAsync();

        return Ok(result);
    }
}
using Microsoft.AspNetCore.Mvc;
using InventoryManagement.Domain.Models.Abstract;
using InventoryManagement.Domain.Models;

namespace InventoryManagement.Api.Controllers;

[Route("v1/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productServiceters)
    {
        _productService = productServiceters;
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<Product>> GetProduct(int Id)
    {
        var result = await _productService.Get(Id);

        if (result == null)
          return NotFound();

        return Ok(result);
    }

    // 1) Count the number of products sold, damaged, and in stock.
    // Did you want a number? Or do you want to see the actual products that are in a certain state?
    [HttpGet("{ProductStatus}/products")]
    public async Task<ActionResult<List<Product>>> GetProductStatus(string ProductStatus)
    {
        Status enumvalue;
        Enum.TryParse<Status>(ProductStatus, out enumvalue);
        
        var enumIndex = (int)enumvalue;

        if (enumIndex > 3 || enumIndex < 1)
          return NotFound();

        var result = await _productService.GetProductStatus(enumvalue);

        return Ok(result);
    }

    // 2) Change the status of a product.
    // 3) Selling a product falls within the same enum. Was this question meant to be something else?
    [HttpPut("{id}")]
    public async Task<ActionResult<Product>> UpdateStatus(int id, Product product)
    {
        if (id != product.Id)
          return BadRequest();

        var productToUpdate = await _productService.Get(id);
        if (productToUpdate == null)
          return NotFound($"Product with Id = {id} not found");

        var result = await _productService.Update(product);

        if (result == null)
          return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> AddProduct(Product product)
    {
        var statusValue = (int) product.Status;
        if (statusValue > 3 || statusValue < 1)
          return BadRequest();

        var result = await _productService.Add(product);

        return CreatedAtAction(nameof(GetProduct), new { Id = product.Id}, product);
    }
}
using InventoryManagement.Infrastructure.Context;
using InventoryManagement.Domain.Models;
using InventoryManagement.Domain.Models.Abstract;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.Data;

public class ProductRepository : IProductRepository
{
    private readonly ProductContext _context;

    public ProductRepository(ProductContext context)
    {
        _context = context;
    }

     public async Task<Product> Get(int Id)
    {
        var result = await _context.Products.FindAsync(Id);

        return result;
    }

    public async Task<Product> Create(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<Product> Update(Product product)
    {
        var existingProduct = await _context.Products.Where(p => p.Id == product.Id)
        .FirstOrDefaultAsync<Product>();

        if (existingProduct != null)
        {
            existingProduct.Status = product.Status;

            _context.SaveChanges();
        }

       return product;
    }

    public async Task<List<Product>> GetProductStatus(Status productStatus)
    {
        var status = Enum.GetNames(typeof(Status)).ToList();

        var result = _context.Products.Where(d => ((int)d.Status) == (int)productStatus).ToList();
        
        return result;
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }
}
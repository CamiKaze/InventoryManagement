using InventoryManagement.Domain.Models;

namespace InventoryManagement.Domain.Models.Abstract;

public interface IProductRepository
{
    Task<Product> Get(int Id);
    Task<List<Product>> GetProductStatus(Status productStatus);
    Task<Product> Create(Product product);
    Task<Product> Update(Product product);

    IEnumerable<Product> GetAll();
    //Product Get(int Id);
    
    void Delete(int id);
    
    //void Create(Product product);
    
    bool SaveChanges();
}
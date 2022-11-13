using InventoryManagement.Domain.Models;

namespace InventoryManagement.Domain.Models.Abstract;

public interface IProductService
{
    Task<Product> Get(int Id);
    Task<List<Product>> GetProductStatus(Status productStatus);
    Task<Product> Add(Product product);
    Task<Product> Update(Product product);


    IEnumerable<Product> GetProducts();
    //Product Get(int Id);
    
    Task<int> CountProducts();

    void Delete(int id);
    
    //void Create(Product product);
    
    bool SaveChanges();
}
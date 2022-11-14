namespace InventoryManagement.Domain.Models.Abstract;

public interface IProductService
{
    Task<Product> Get(int Id);
    Task<List<Product>> GetProductStatus(Status productStatus);
    Task<Product> Add(Product product);
    Task<Product> Update(Product product);
    IEnumerable<Product> GetProducts();
    Task<int> CountProducts();
    void Delete(int id);
    bool SaveChanges();
}
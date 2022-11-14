namespace InventoryManagement.Domain.Models.Abstract;

public interface IProductRepository
{
    Task<Product> Get(int Id);
    Task<List<Product>> GetProductStatus(Status productStatus);
    Task<Product> Create(Product product);
    Task<Product> Update(Product product);

    IEnumerable<Product> GetAll();
    void Delete(int id);
    bool SaveChanges();
}
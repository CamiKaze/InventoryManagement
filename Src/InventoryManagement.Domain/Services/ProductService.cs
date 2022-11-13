using InventoryManagement.Domain.Models;
using InventoryManagement.Domain.Models.Abstract;

namespace InventoryManagement.Domain.Services;

public class ProductService : IProductService
//public class ProductService : IProductRepository

{
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Get(int Id)
    {
        var result = await _productRepository.Get(Id);

        return result;
    }

    public async Task<List<Product>> GetProductStatus(Status productStatus)
    {
        var result = await _productRepository.GetProductStatus(productStatus);

        return result;
    }






     public async Task<Product> Add(Product product)
    {
        var result = await _productRepository.Create(product);

        return result;
    }

    public async Task<Product> Update(Product product)
    {
        var result = await _productRepository.Update(product);

        return result;
    }










    public Task<int> CountProducts()
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    




    public IEnumerable<Product> GetProducts()
    {
        throw new NotImplementedException();
    }

    public bool SaveChanges()
    {
        throw new NotImplementedException();
    }


    // public Task<int> CountProducts()
    // {
    //     throw new NotImplementedException();
    // }

    // public Product Get(int Id)
    // {
    //     var result = _productRepository.Get(Id);

    //     return result;
    // }

    // public IEnumerable<Product> GetProducts()
    // {
    //     throw new NotImplementedException();
    // }
}
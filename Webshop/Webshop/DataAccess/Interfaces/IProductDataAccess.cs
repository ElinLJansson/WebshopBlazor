using Webshop.Models;

namespace Webshop.DataAccess.Interfaces;

public interface IProductDataAccess
{
    Task<List<Product>> GetAllProductsAsync();
    Task<Product> GetProductAsync(int id);
    Task<int> GetProductStockQuantityAsync(int id);
    Task UpdateProductStockQuantityAsync (Product product, int quantitySold);
}

using Microsoft.EntityFrameworkCore;
using Webshop.Data;
using Webshop.DataAccess.Interfaces;
using Webshop.Models;

namespace Webshop.DataAccess;

public class ProductDataAccess : IProductDataAccess
{
    private readonly DataContext _dataContext;

    public ProductDataAccess(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        var result = await _dataContext.Products.ToListAsync();
        return result;
    }

    public async Task<Product> GetProductAsync(int id)
    {
        var result = await _dataContext.Products.FirstOrDefaultAsync(p => p.Id.Equals(id));
        return result;
    }

    public async Task<int> GetProductStockQuantityAsync(int id)
    {
        var product = await GetProductAsync(id);
        return product.StockQuantity;
    }

    public async Task UpdateProductStockQuantityAsync(Product product, int quantitySold)
    {
        product.StockQuantity -= quantitySold;
        _dataContext.Products.Update(product);
        await _dataContext.SaveChangesAsync();
    }
}

using Webshop.Data;
using Webshop.Models;

namespace Webshop.DataAccess.Interfaces;

public interface IShoppingCartDataAccess
{
    Task<List<Product>> GetProductsFromUserCartAsync();
    Task AddProductToUserCartAsync(Product product);
    Task<int> GetProductQuantityFromUserCartAsync(Product product);
    Task RemoveProductFromUserCartAsync(Product product);
    Task ReduceProductQuantityFromUserCartAsync(Product product, int quantity);
    Task EmptyUserCartAsync();
}

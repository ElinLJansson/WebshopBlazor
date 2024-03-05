using Microsoft.EntityFrameworkCore;
using Webshop.Data;
using Webshop.DataAccess.Interfaces;
using Webshop.Models;

namespace Webshop.DataAccess;

public class ShoppingCartDataAccess : IShoppingCartDataAccess
{
    private readonly DataContext _dataContext;
    private readonly UserAccess _userAccess;

    public ShoppingCartDataAccess(DataContext dataContext, UserAccess userAccess)
    {
        _dataContext = dataContext;
        _userAccess = userAccess;
    }
    
    public async Task AddProductToUserCartAsync(Product product)
    {
        var user = await _userAccess.GetCurrentUser();
        
        if (user.ShoppingCart is null)
        {
            await CreateNewUserCartAsync(user);
        }

        if (await ProductAlredyInUserCartAsync(product))
        {
            // kan vara egen metod IncreaseProductQuantityInUserCartByOne(Product product, ApplicationUser user)
            var shoppingCartProduct = await GetShoppingCartProducts(product);

            shoppingCartProduct.Quantity++;

            _dataContext.ShoppingCartProducts.Update(shoppingCartProduct);

            await _dataContext.SaveChangesAsync();
        }
        else
        {
            // kan vara egen metod AddNewProductToUserCart(Product product, ApplicationUser user)
            var productToAdd = new ShoppingCartProduct
            {
                Product = product,
                ShoppingCart = user.ShoppingCart
            };

            await _dataContext.ShoppingCartProducts.AddAsync(productToAdd);

            await _dataContext.SaveChangesAsync();
        }
    }

    public async Task<List<Product>> GetProductsFromUserCartAsync()
    {
        var user = await _userAccess.GetCurrentUser();

        if (user.ShoppingCart is not null)
        {
            var productIds = await _dataContext.ShoppingCartProducts
                .Where(c => c.ShoppingCartId == user.ShoppingCart.Id)
                .Select(c => c.ProductId)
                .ToListAsync();

            var products = await _dataContext.Products
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync();

            return products;
        }
        return new List<Product>();
    }

    public async Task<int> GetProductQuantityFromUserCartAsync(Product product)
    {
        var shoppingCartProduct = await GetShoppingCartProducts(product);

        return shoppingCartProduct.Quantity; 
    }

    public async Task RemoveProductFromUserCartAsync(Product product)
    {
        var shoppingCartProduct = await GetShoppingCartProducts(product);

        _dataContext.ShoppingCartProducts.Remove(shoppingCartProduct);

        await _dataContext.SaveChangesAsync();
    }

    public async Task ReduceProductQuantityFromUserCartAsync(Product product, int quantity)
    {
        var shoppingCartProduct = await GetShoppingCartProducts(product);

        shoppingCartProduct.Quantity -= quantity;

        _dataContext.ShoppingCartProducts.Update(shoppingCartProduct);

        await _dataContext.SaveChangesAsync();
    }

    public async Task EmptyUserCartAsync()
    {
        var user = await _userAccess.GetCurrentUser();

        var cart = await _dataContext.ShoppingCartProducts
                .Where(c => c.ShoppingCartId == user.ShoppingCart.Id)
                .ExecuteDeleteAsync();

        await _dataContext.SaveChangesAsync();
    }

    private async Task CreateNewUserCartAsync(ApplicationUser user)
    {
        var newShoppingCart = new ShoppingCart  
        {
            Id = user.Id,
            ShoppingCarts = new List<ShoppingCartProduct>()
        };

        await _dataContext.ShoppingCarts.AddAsync(newShoppingCart);

        await _dataContext.SaveChangesAsync();
    }

    private async Task<bool> ProductAlredyInUserCartAsync(Product product)
    {
        var userCart = await GetProductsFromUserCartAsync();

        var result = userCart.Contains(product);

        return result;
    }

    private async Task<ShoppingCartProduct> GetShoppingCartProducts(Product product)
    {
        var user = await _userAccess.GetCurrentUser();

        var shoppingCartProduct = await _dataContext.ShoppingCartProducts
                .FirstOrDefaultAsync(scp => scp.ProductId == product.Id && scp.ShoppingCartId == user.Id);

        return shoppingCartProduct;
    }
}

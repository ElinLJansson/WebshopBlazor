using Webshop.Data;

namespace Webshop.Models;

public class ShoppingCart
{
    public string Id { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public List<ShoppingCartProduct> ShoppingCarts { get; set; } = new();
}

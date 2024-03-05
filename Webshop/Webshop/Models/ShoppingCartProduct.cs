using System.ComponentModel.DataAnnotations.Schema;

namespace Webshop.Models;

public class ShoppingCartProduct
{
    [ForeignKey("Product")]
    public int ProductId { get; set; } 
    public Product Product { get; set; }


    [ForeignKey("ShoppingCart")]
    public string ShoppingCartId { get; set; }
    public ShoppingCart ShoppingCart { get; set; }

    public int Quantity { get; set; }
}



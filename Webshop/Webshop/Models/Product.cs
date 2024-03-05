using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Webshop.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    public int ProductNumber { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public int? DiscountPercent { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? DiscountPrice { get; set; }

    public int StockQuantity { get; set; }
    public string ImgURL { get; set; }
    public List<ShoppingCartProduct> ShoppingCarts { get; set; } = new();
}

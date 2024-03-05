namespace Webshop.Client.Models;

public class ClientSideProduct
{
    public int Id { get; set; }
    public int ProductNumber { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int? DiscountPercent { get; set; }
    public decimal? DiscountPrice { get; set; }
    public string ImgURL { get; set; }
    public int Quantity { get; set;}
}

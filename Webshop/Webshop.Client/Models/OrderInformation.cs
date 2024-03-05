namespace Webshop.Client.Models;

public class OrderInformation
{
	public string Name { get; set; }
	public string Email { get; set; }
	public string Street { get; set; }
	public string City { get; set; }
	public string ZipCode { get; set; }
	public List<ClientSideProduct> Products { get; set; } = new();
}

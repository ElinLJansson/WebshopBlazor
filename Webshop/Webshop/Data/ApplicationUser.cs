using Microsoft.AspNetCore.Identity;
using Webshop.Models;


namespace Webshop.Data;

public class ApplicationUser : IdentityUser
{
    public ShoppingCart ShoppingCart { get; set; }
}

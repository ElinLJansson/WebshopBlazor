using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Webshop.Data;

namespace Webshop.DataAccess;

public class UserAccess
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly AuthenticationStateProvider _stateProvider;
    
    public UserAccess(UserManager<ApplicationUser> userManager, AuthenticationStateProvider stateProvider)
    {
        _userManager = userManager;
        _stateProvider = stateProvider;
    }

    public async Task<ApplicationUser> GetCurrentUser()
    {
        AuthenticationState authenticationState = await _stateProvider.GetAuthenticationStateAsync();

        var stateUser = await _userManager.GetUserAsync(authenticationState.User);

        ApplicationUser user = await GetUserCartInfo(stateUser);

        return user;
    }

    private async Task<ApplicationUser> GetUserCartInfo(ApplicationUser user)
    {
        return await _userManager.Users
            .Include(x => x.ShoppingCart)
            .FirstOrDefaultAsync(x => x.Id == user.Id);
    }

    public async Task<string> GetCurrentUserId()
    {
        AuthenticationState authenticationState = await _stateProvider.GetAuthenticationStateAsync();

        var userId = authenticationState
                .User
                .Claims
                .Where(c => c.Type == ClaimTypes.NameIdentifier)
                .First()
                .Value;

        return userId;
    }
}

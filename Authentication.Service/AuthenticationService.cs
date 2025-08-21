using Authentication.Service.Models;

namespace Authentication.Service
{
    // All the code in this file is included in all platforms.
    public interface IAuthenticationService
    {
        Task<bool> LoginAsync(string email, string password);
        Task<bool> RegisterAsync(string fullname, string password, string email);
        Task LogoutAsync();
        Task<bool> IsAuthenticatedAsync();
        Task<UserConnected> GetUserConnectedAsync();
    }
}

using Authentication.Service.Models;
using Firebase.Auth;

namespace Authentication.Service
{
    // All the code in this file is only included on Android.
    public partial class AuthenticationService : IAuthenticationService
    {
        public Task<UserConnected> GetUserConnectedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsAuthenticatedAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            try
            {
                var authentication = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                return authentication.User?.Email != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task LogoutAsync()
            => Task.Run(() => FirebaseAuth.Instance.SignOut());

        public Task<bool> RegisterAsync(string fullname, string password, string email)
        {
            try
            {
                var registered
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

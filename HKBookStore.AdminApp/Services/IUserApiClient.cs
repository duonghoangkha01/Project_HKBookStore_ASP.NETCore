using HKBookStore.ViewModels.System.Users;

namespace HKBookStore.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
    }
}

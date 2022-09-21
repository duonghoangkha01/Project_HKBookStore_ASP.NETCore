using HKBookStore.ViewModels.Common;
using HKBookStore.ViewModels.System.Users;

namespace HKBookStore.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
        Task<PagedResult<UserViewModel>> GetUsersPagings(GetUserPagingRequest request);
        Task<bool> RegisterUser(RegisterRequest registerRequest);
    }
}

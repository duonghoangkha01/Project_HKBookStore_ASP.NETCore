using HKBookStore.ViewModels.Common;
using HKBookStore.ViewModels.System.Roles;

namespace HKBookStore.AdminApp.Services
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleViewModel>>> GetAll();
    }
}

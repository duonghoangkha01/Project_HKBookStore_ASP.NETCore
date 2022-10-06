using HKBookStore.ViewModels.Common;
using HKBookStore.ViewModels.System.Roles;

namespace HKBookStore.ApiIntegration
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleViewModel>>> GetAll();
    }
}

using HKBookStore.ViewModels.Catalog.Carts;

namespace HKBookStore.ApiIntegration
{
    public interface ICartApiClient
    {
        Task<bool>  AddItemToCart(int productId);
    }
}

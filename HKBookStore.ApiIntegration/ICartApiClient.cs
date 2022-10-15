using HKBookStore.ViewModels.Catalog.Carts;

namespace HKBookStore.ApiIntegration
{
    public interface ICartApiClient
    {
        Task<List<CartItemViewModel>> GetCarts();
        Task<bool>  AddItemToCart(int productId);
        Task<bool> UpdateCart(int productId, int quantity);
    }
}

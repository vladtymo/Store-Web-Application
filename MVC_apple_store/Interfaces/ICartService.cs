using BusinessLogic.DTOs;

namespace MVC_apple_store.Interfaces
{
    public interface ICartService
    {
        void AddProductToCart(int id);
        void RemoveProductFromCart(int id);
        IEnumerable<PhoneDTO?> GetProductsFromCart();
        bool IsProductInCart(int id);
    }
}

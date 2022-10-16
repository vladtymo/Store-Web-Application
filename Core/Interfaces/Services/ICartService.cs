using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces
{
    public interface ICartService
    {
        void AddProductToCart(int id);
        void RemoveProductFromCart(int id);
        IEnumerable<PhoneDTO?> GetProductsFromCart();
        bool IsProductInCart(int id);
    }
}

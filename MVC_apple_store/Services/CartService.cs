using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using MVC_apple_store.Helpers;
using MVC_apple_store.Interfaces;

namespace MVC_apple_store.Services
{
    public class CartService : ICartService
    {
        private readonly HttpContext? httpContext;
        private readonly IPhoneService phoneService;

        public CartService(IHttpContextAccessor httpContextAccessor,
                           IPhoneService phoneService)
        {
            this.httpContext = httpContextAccessor.HttpContext;
            this.phoneService = phoneService;
        }

        public void AddProductToCart(int id)
        {
            if (httpContext == null) return;

            var productIds = httpContext.Session.GetObject<List<int>>(WebConstants.cartListKey);

            if (productIds == null)
                productIds = new List<int>();

            productIds.Add(id);

            httpContext.Session.SetObject(WebConstants.cartListKey, productIds);
        }
        public void RemoveProductFromCart(int id)
        {
            if (httpContext == null) return;

            var productIds = httpContext.Session.GetObject<List<int>>(WebConstants.cartListKey);

            if (productIds == null) return;

            productIds.Remove(id);

            httpContext.Session.SetObject(WebConstants.cartListKey, productIds);
        }
        public IEnumerable<PhoneDTO> GetProductsFromCart()
        {
            if (httpContext == null) return new List<PhoneDTO>();

            var productIds = httpContext.Session.GetObject<List<int>>(WebConstants.cartListKey);
            if (productIds == null) return new List<PhoneDTO>();

            List<PhoneDTO> phones = phoneService.GetPhones(productIds.ToArray());

            return phones;
        }
        public bool IsProductInCart(int id)
        {
            if (httpContext == null) return false;

            var productIds = httpContext.Session.GetObject<List<int>>(WebConstants.cartListKey);

            if (productIds == null) return false;

            return productIds.Contains(id);
        }
    }
}

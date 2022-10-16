using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MVC_apple_store.Controllers
{
    public class CartController : Controller
    {
        private readonly IPhoneService phoneService;
        private readonly ICartService cartService;

        public CartController(IPhoneService phoneService,
                              ICartService cartService)
        {
            this.phoneService = phoneService;
            this.cartService = cartService;
        }

        public IActionResult Index()
        {
            var products = cartService.GetProductsFromCart();

            return View(products);
        }

        public IActionResult Add(int productId)
        {
            if (productId < 0) return BadRequest();

            var phone = phoneService.GetPhone(productId);

            if (phone == null) return NotFound();

            cartService.AddProductToCart(productId);

            return RedirectToAction("Details", "Phones", new { id = productId });
        }
        public IActionResult Remove(int productId)
        {
            if (productId < 0) return BadRequest();

            var phone = phoneService.GetPhone(productId);

            if (phone == null) return NotFound();

            cartService.RemoveProductFromCart(productId);

            return RedirectToAction("Details", "Phones", new { id = productId });
        }
    }
}

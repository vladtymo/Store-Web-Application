using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_apple_store.Helpers;
using MVC_apple_store.Interfaces;

namespace MVC_apple_store.Controllers
{
    public class PhonesController : Controller
    {
        private readonly IPhoneService phoneService;
        private readonly ICartService cartService;

        public PhonesController(IPhoneService phoneService,
                                ICartService cartService)
        {
            this.phoneService = phoneService;
            this.cartService = cartService;
        }

        // GET: /Phones/Index or /Phones
        public IActionResult Index()
        {
            return View(phoneService.GetAllPhones());
        }

        // GET: /Phones/Manage
        public IActionResult Manage()
        {
            return View(phoneService.GetAllPhones());
        }

        // GET: /Phones/Details/{id}
        public IActionResult Details(int id)
        {
            if (id < 0) return BadRequest();

            var phone = phoneService.GetPhone(id);

            if (phone == null) return NotFound();

            ViewBag.IsInCart = cartService.IsProductInCart(id);

            return View(phone);
        }

        // GET: /Phones/Create
        public IActionResult Create()
        {
            var colors = new SelectList(phoneService.GetAllColors(), nameof(ColorDTO.Id), nameof(ColorDTO.Name));

            ViewBag.ColorList = colors;

            return View();
        }

        // POST: /Phones/Create
        [HttpPost]
        public IActionResult Create(PhoneDTO phone)
        {
            if (!ModelState.IsValid)
            {
                var colors = new SelectList(phoneService.GetAllColors(), nameof(ColorDTO.Id), nameof(ColorDTO.Name));
                
                ViewBag.ColorList = colors;
                
                return View(phone);
            }

            phoneService.CreatePhone(phone);

            TempData[WebConstants.alertMsgKey] = "Phone has been successfully created!";

            return RedirectToAction(nameof(Manage));
        }

        // GET: /Phones/Edit/{id}
        public IActionResult Edit(int id)
        {
            if (id < 0) return BadRequest();

            var phone = phoneService.GetPhone(id);

            if (phone == null) return NotFound();

            var colors = new SelectList(phoneService.GetAllColors(), nameof(ColorDTO.Id), nameof(ColorDTO.Name));
            ViewBag.ColorList = colors;

            return View(phone);
        }

        // POST: /Phones/Edit
        [HttpPost]
        public IActionResult Edit(PhoneDTO phone)
        {
            if (!ModelState.IsValid)
            {
                var colors = new SelectList(phoneService.GetAllColors(), nameof(ColorDTO.Id), nameof(ColorDTO.Name));

                ViewBag.ColorList = colors;

                return View(phone);
            }

            phoneService.UpdatePhone(phone);

            TempData[WebConstants.alertMsgKey] = "Phone has been successfully edited!";

            return RedirectToAction(nameof(Manage));
        }

        // GET: /Phones/Delete/{id}
        public IActionResult Delete(int id)
        {
            if (id < 0) return BadRequest();

            var phone = phoneService.GetPhone(id);

            if (phone == null) return NotFound();

            phoneService.DeletePhone(id);

            TempData[WebConstants.alertMsgKey] = "Phone has been successfully deleted!";

            return RedirectToAction(nameof(Manage));
        }
    }
}

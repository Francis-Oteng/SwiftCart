using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftCart.Data;
using SwiftCart.Models;

namespace SwiftCart.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CheckoutController : Controller
    {
        private readonly SwiftCartDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CheckoutController(
            SwiftCartDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);

            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null || !cart.CartItems.Any())
                return RedirectToAction("Index", "Cart");

            var addresses = await _context.Addresses
                .Where(a => a.UserId == userId)
                .ToListAsync();

            ViewBag.Addresses = addresses;

            return View(cart);
        }

        [HttpPost]
        public IActionResult SelectAddress(int addressId)
        {
            TempData["AddressId"] = addressId;

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult SelectDeliverySlot(
            string deliverySlot)
        {
            TempData["DeliverySlot"] = deliverySlot;

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder(
            int addressId,
            string deliverySlot)
        {
            var userId = _userManager.GetUserId(User);

            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null || !cart.CartItems.Any())
                return RedirectToAction("Index", "Cart");

            // Create Order here.
            // Calculate subtotal, delivery fee, tax and total.
            // Create OrderItems.
            // Create Payment.
            // Clear Cart.

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Confirmation));
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}
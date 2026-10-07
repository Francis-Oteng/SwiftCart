using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftCart.Data;
using SwiftCart.Models;

namespace SwiftCart.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CartController : Controller
    {
        private readonly SwiftCartDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(
            SwiftCartDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: /Cart
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            return View(cart);
        }

        // POST: /Cart/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(
            int productId,
            int quantity = 1)
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            if (quantity <= 0)
                quantity = 1;

            // Find the customer's cart
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            // Create cart if customer doesn't have one
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId
                };

                _context.Carts.Add(cart);

                await _context.SaveChangesAsync();
            }

            // Check whether product is already in cart
            var item = cart.CartItems
                .FirstOrDefault(x => x.ProductId == productId);

            if (item == null)
            {
                // Add a new CartItem
                var newItem = new CartItem
                {
                    CartId = cart.CartId,
                    ProductId = productId,
                    Quantity = quantity
                };

                cart.CartItems.Add(newItem);
            }
            else
            {
                // Increase existing quantity
                item.Quantity += quantity;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: /Cart/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(
            int cartItemId,
            int quantity)
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var item = await _context.CartItems
                .Include(ci => ci.Cart)
                .FirstOrDefaultAsync(
                    ci => ci.CartItemId == cartItemId &&
                          ci.Cart.UserId == userId);

            if (item == null)
                return NotFound();

            if (quantity <= 0)
            {
                _context.CartItems.Remove(item);
            }
            else
            {
                item.Quantity = quantity;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: /Cart/Remove
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int id)
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var item = await _context.CartItems
                .Include(ci => ci.Cart)
                .FirstOrDefaultAsync(
                    ci => ci.CartItemId == id &&
                          ci.Cart.UserId == userId);

            if (item == null)
                return NotFound();

            _context.CartItems.Remove(item);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: /Cart/Clear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Clear()
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart != null)
            {
                _context.CartItems.RemoveRange(cart.CartItems);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
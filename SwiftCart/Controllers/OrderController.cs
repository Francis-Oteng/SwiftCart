using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftCart.Data;
using SwiftCart.Models;

namespace SwiftCart.Controllers
{
    [Authorize(Roles = "Customer")]
    public class OrderController : Controller
    {
        private readonly SwiftCartDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(
            SwiftCartDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: /Order
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var orders = await _context.Orders
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.CreatedDate)
                .ToListAsync();

            return View(orders);
        }

        // GET: /Order/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(
                    o => o.OrderId == id &&
                         o.UserId == userId);

            if (order == null)
                return NotFound();

            return View(order);
        }

        // POST: /Order/Cancel/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var order = await _context.Orders
                .FirstOrDefaultAsync(
                    o => o.OrderId == id &&
                         o.UserId == userId);

            if (order == null)
                return NotFound();

            order.Status = OrderStatus.Cancelled;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id });
        }

        // GET: /Order/Track/5
        public async Task<IActionResult> Track(int id)
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            // First make sure the order belongs to the logged-in customer
            var orderExists = await _context.Orders
                .AnyAsync(o => o.OrderId == id && o.UserId == userId);

            if (!orderExists)
                return NotFound();

            var delivery = await _context.Deliveries
                .Include(d => d.TrackingHistory)
                .FirstOrDefaultAsync(d => d.OrderId == id);

            if (delivery == null)
                return NotFound();

            return View(delivery);
        }

        // GET: /Order/History
        public async Task<IActionResult> History()
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var orders = await _context.Orders
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.CreatedDate)
                .ToListAsync();

            return View(orders);
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftCart.Data;
using SwiftCart.Models;
using SwiftCart.Models.ViewModels.Order;

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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(i => i.Product)
                .Include(o => o.Store)
                .Where(o => o.CustomerId == userId)
                .OrderByDescending(o => o.CreatedDate)
                .ToListAsync();

            var model = new OrderListViewModel
            {
                Orders = orders.Select(order =>
                    new OrderSummaryViewModel
                    {
                        OrderId = order.OrderId,
                        CreatedDate = order.CreatedDate
                    }).ToList()
            };

            return View(model);
        }

        // GET: /Order/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var order = await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(i => i.Product)
                .Include(o => o.Store)
                .FirstOrDefaultAsync(
                    o => o.OrderId == id &&
                         o.CustomerId == userId);

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
                         o.CustomerId == userId);

            if (order == null)
                return NotFound();

            // Prevent cancellation of completed or already cancelled orders
            if (order.Status == OrderStatus.Delivered ||
                order.Status == OrderStatus.Cancelled)
            {
                return RedirectToAction(
                    nameof(Details),
                    new { id });
            }

            order.Status = OrderStatus.Cancelled;

            await _context.SaveChangesAsync();

            return RedirectToAction(
                nameof(Details),
                new { id });
        }

        // GET: /Order/Track/5
        [HttpGet]
        public async Task<IActionResult> Track(int id)
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            // Find the customer's order
            var order = await _context.Orders
                .Include(o => o.Store)
                .FirstOrDefaultAsync(
                    o => o.OrderId == id &&
                         o.CustomerId == userId);

            if (order == null)
                return NotFound();

            // Find the delivery associated with this order
            var delivery = await _context.Deliveries
                .Include(d => d.TrackingHistory)
                .FirstOrDefaultAsync(
                    d => d.OrderId == order.OrderId);

            // Build tracking steps
            var steps = new List<OrderTrackingStepViewModel>
            {
                new OrderTrackingStepViewModel
                {
                    Title = "Order Placed",
                    Description = "Your order has been placed successfully.",
                    IsCompleted = true,
                    IsCurrent = order.Status == OrderStatus.Pending,
                    Timestamp = order.CreatedDate
                },

                new OrderTrackingStepViewModel
                {
                    Title = "Order Confirmed",
                    Description = "The store has confirmed your order.",
                    IsCompleted =
                        order.Status >= OrderStatus.Confirmed,
                    IsCurrent =
                        order.Status == OrderStatus.Confirmed
                },

                new OrderTrackingStepViewModel
                {
                    Title = "Preparing",
                    Description = "The store is preparing your order.",
                    IsCompleted =
                        order.Status >= OrderStatus.Preparing,
                    IsCurrent =
                        order.Status == OrderStatus.Preparing
                },

                new OrderTrackingStepViewModel
                {
                    Title = "Ready for Pickup",
                    Description = "Your order is ready for pickup.",
                    IsCompleted =
                        order.Status >= OrderStatus.ReadyForPickup,
                    IsCurrent =
                        order.Status == OrderStatus.ReadyForPickup
                },

                new OrderTrackingStepViewModel
                {
                    Title = "Picked Up",
                    Description = "The rider has picked up your order.",
                    IsCompleted =
                        order.Status >= OrderStatus.PickedUp,
                    IsCurrent =
                        order.Status == OrderStatus.PickedUp
                },

                new OrderTrackingStepViewModel
                {
                    Title = "In Transit",
                    Description = "Your order is on the way.",
                    IsCompleted =
                        order.Status >= OrderStatus.InTransit,
                    IsCurrent =
                        order.Status == OrderStatus.InTransit
                },

                new OrderTrackingStepViewModel
                {
                    Title = "Delivered",
                    Description = "Your order has been delivered.",
                    IsCompleted =
                        order.Status == OrderStatus.Delivered,
                    IsCurrent =
                        order.Status == OrderStatus.Delivered
                }
            };

            // Build the tracking ViewModel
            var model = new OrderTrackingViewModel
            {
                OrderNumber = $"ORD-{order.OrderId:D6}",

                // IMPORTANT:
                // Status is an OrderStatus enum.
                // Do NOT use order.Status.ToString().
                Status = order.Status,

                // Your current Delivery model does not contain
                // a DeliveryAddress property.
                DeliveryAddress = "Address unavailable",

                DeliveryId = delivery?.DeliveryId,

                Steps = steps
            };

            return View(model);
        }

        // GET: /Order/History
        [HttpGet]
        public async Task<IActionResult> History()
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(i => i.Product)
                .Include(o => o.Store)
                .Where(o => o.CustomerId == userId)
                .OrderByDescending(o => o.CreatedDate)
                .ToListAsync();

            var model = new OrderListViewModel
            {
                Orders = orders.Select(order =>
                    new OrderSummaryViewModel
                    {
                        OrderId = order.OrderId,
                        CreatedDate = order.CreatedDate
                    }).ToList()
            };

            return View(model);
        }
    }
}


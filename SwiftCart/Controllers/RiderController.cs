using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftCart.Data;
using SwiftCart.Models;

namespace SwiftCart.Controllers
{
    [Authorize(Roles = "Rider")]
    public class RiderController : Controller
    {
        private readonly SwiftCartDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RiderController(
            SwiftCartDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public async Task<IActionResult> Profile()
        {
            var userId = _userManager.GetUserId(User);

            var rider = await _context.Riders
                .FirstOrDefaultAsync(r => r.UserId == userId);

            if (rider == null)
                return NotFound();

            return View(rider);
        }

        public async Task<IActionResult> AvailableDeliveries()
        {
            var deliveries = await _context.Deliveries
                .Where(d => d.RiderId == null)
                .ToListAsync();

            return View(deliveries);
        }

        public async Task<IActionResult> MyDeliveries()
        {
            var userId = _userManager.GetUserId(User);

            var rider = await _context.Riders
                .FirstOrDefaultAsync(r => r.UserId == userId);

            if (rider == null)
                return NotFound();

            var deliveries = await _context.Deliveries
                .Where(d => d.RiderId == rider.RiderId)
                .ToListAsync();

            return View(deliveries);
        }

        [HttpPost]
        public async Task<IActionResult> AcceptDelivery(int id)
        {
            var userId = _userManager.GetUserId(User);

            var rider = await _context.Riders
                .FirstOrDefaultAsync(r => r.UserId == userId);

            if (rider == null)
                return NotFound();

            var delivery = await _context.Deliveries
                .FirstOrDefaultAsync(d => d.DeliveryId == id);

            if (delivery == null)
                return NotFound();

            delivery.RiderId = rider.RiderId;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MyDeliveries));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(
            int id,
            string status)
        {
            var delivery = await _context.Deliveries
                .FindAsync(id);

            if (delivery == null)
                return NotFound();

            // Set your DeliveryStatus enum here.

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MyDeliveries));
        }

        [HttpPost]
        public async Task<IActionResult> ToggleAvailability()
        {
            var userId = _userManager.GetUserId(User);

            var rider = await _context.Riders
                .FirstOrDefaultAsync(r => r.UserId == userId);

            if (rider == null)
                return NotFound();

            rider.IsAvailable = !rider.IsAvailable;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Dashboard));
        }
    }
}
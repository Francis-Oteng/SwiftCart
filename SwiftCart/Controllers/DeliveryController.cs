using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftCart.Data;
using SwiftCart.Models;

namespace SwiftCart.Controllers
{
    [Authorize]
    public class DeliveryController : Controller
    {
        private readonly SwiftCartDbContext _context;

        public DeliveryController(SwiftCartDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Details(int id)
        {
            var delivery = await _context.Deliveries
                .Include(d => d.TrackingHistory)
                .FirstOrDefaultAsync(d => d.DeliveryId == id);

            if (delivery == null)
                return NotFound();

            return View(delivery);
        }

        public async Task<IActionResult> Track(int id)
        {
            var tracking = await _context.DeliveryTrackings
                .Where(t => t.DeliveryId == id)
                .OrderByDescending(t => t.CreatedDate)
                .ToListAsync();

            return View(tracking);
        }

        [Authorize(Roles = "Rider")]
        [HttpPost]
        public async Task<IActionResult> UpdateLocation(
            int deliveryId,
            decimal latitude,
            decimal longitude)
        {
            var tracking = new DeliveryTracking
            {
                DeliveryId = deliveryId,
                Latitude = latitude,
                Longitude = longitude,
                CreatedDate = DateTime.UtcNow
            };

            _context.DeliveryTrackings.Add(tracking);

            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

        [Authorize(Roles = "Rider")]
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(
            int id,
            string status)
        {
            var delivery = await _context.Deliveries.FindAsync(id);

            if (delivery == null)
                return NotFound();

            // Set DeliveryStatus here.

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize(Roles = "Rider")]
        [HttpPost]
        public async Task<IActionResult> Complete(int id)
        {
            var delivery = await _context.Deliveries.FindAsync(id);

            if (delivery == null)
                return NotFound();

            // Set status to Completed.

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
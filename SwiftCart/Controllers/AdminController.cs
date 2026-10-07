using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftCart.Data;
using SwiftCart.Models;

namespace SwiftCart.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly SwiftCartDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(
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

        public async Task<IActionResult> Users()
        {
            var users = await _userManager.Users
                .OrderByDescending(u => u.CreatedDate)
                .ToListAsync();

            return View(users);
        }

        public async Task<IActionResult> Stores()
        {
            var stores = await _context.Stores
                .ToListAsync();

            return View(stores);
        }

        public async Task<IActionResult> Riders()
        {
            var riders = await _context.Riders
                .ToListAsync();

            return View(riders);
        }

        public async Task<IActionResult> Orders()
        {
            var orders = await _context.Orders
                .OrderByDescending(o => o.CreatedDate)
                .ToListAsync();

            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveStore(int id)
        {
            var store = await _context.Stores.FindAsync(id);

            if (store == null)
                return NotFound();

            store.Status = StoreStatus.Approved;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Stores));
        }

        [HttpPost]
        public async Task<IActionResult> RejectStore(int id)
        {
            var store = await _context.Stores.FindAsync(id);

            if (store == null)
                return NotFound();

            store.Status = StoreStatus.Rejected;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Stores));
        }

        [HttpPost]
        public async Task<IActionResult> ApproveRider(int id)
        {
            var rider = await _context.Riders.FindAsync(id);

            if (rider == null)
                return NotFound();

            rider.ApprovalStatus = RiderApprovalStatus.Approved;
            rider.ApprovedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Riders));
        }

        [HttpPost]
        public async Task<IActionResult> RejectRider(int id)
        {
            var rider = await _context.Riders.FindAsync(id);

            if (rider == null)
                return NotFound();

            rider.ApprovalStatus = RiderApprovalStatus.Rejected;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Riders));
        }

        [HttpPost]
        public async Task<IActionResult> SuspendUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound();

            user.IsActive = false;

            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Users));
        }
    }
}
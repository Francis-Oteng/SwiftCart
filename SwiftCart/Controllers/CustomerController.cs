using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftCart.Data;
using SwiftCart.Models;
using SwiftCart.Models.ViewModels.Customer;

namespace SwiftCart.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {
        private readonly SwiftCartDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomerController(
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
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            var model = new CustomerProfileViewModel
            {
                FullName = user.FullName,
                Email = user.Email ?? string.Empty,
                PhoneNumber = user.PhoneNumber,
                UserId = user.Id
            };

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(
            ApplicationUser model)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound();

            user.FullName = model.FullName;
            user.PhoneNumber = model.PhoneNumber;

            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Profile));
        }

        public async Task<IActionResult> Addresses()
        {
            var userId = _userManager.GetUserId(User);

            var addresses = await _context.Addresses
                .Where(a => a.UserId == userId)
                .ToListAsync();

            return View(addresses);
        }

        public IActionResult AddAddress()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAddress(Address address)
        {
            if (!ModelState.IsValid)
                return View(address);

            address.UserId = _userManager.GetUserId(User)!;

            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Addresses));
        }

        public async Task<IActionResult> EditAddress(int id)
        {
            var address = await _context.Addresses.FindAsync(id);

            if (address == null)
                return NotFound();

            return View(address);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAddress(
            int id,
            Address address)
        {
            if (id != address.AddressId)
                return NotFound();

            if (!ModelState.IsValid)
                return View(address);

            _context.Addresses.Update(address);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Addresses));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var address = await _context.Addresses.FindAsync(id);

            if (address == null)
                return NotFound();

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Addresses));
        }
    }
}
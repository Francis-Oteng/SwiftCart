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

        // =========================================================
        // CUSTOMER DASHBOARD
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var model = new CustomerProfileViewModel
            {
                UserId = user.Id,
                FullName = user.FullName ?? string.Empty,
                Email = user.Email ?? string.Empty,
                PhoneNumber = user.PhoneNumber,

                TotalOrders = await _context.Orders
                    .CountAsync(o => o.CustomerId == user.Id),

                SavedAddresses = await _context.Addresses
                    .CountAsync(a => a.UserId == user.Id)
            };

            return View(model);
        }

        // =========================================================
        // CUSTOMER PROFILE
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            var model = new CustomerProfileViewModel
            {
                UserId = user.Id,
                FullName = user.FullName ?? string.Empty,
                Email = user.Email ?? string.Empty,
                PhoneNumber = user.PhoneNumber,

                TotalOrders = await _context.Orders
                    .CountAsync(o => o.CustomerId == user.Id),

                SavedAddresses = await _context.Addresses
                    .CountAsync(a => a.UserId == user.Id)
            };

            return View(model);
        }

        // =========================================================
        // EDIT CUSTOMER PROFILE - GET
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            var model = new EditCustomerProfileViewModel
            {
                FullName = user.FullName ?? string.Empty,
                Email = user.Email ?? string.Empty,
                PhoneNumber = user.PhoneNumber,
                ExistingProfilePhotoUrl = user.ProfilePhotoUrl
            };

            return View(model);
        }

        // =========================================================
        // EDIT CUSTOMER PROFILE - POST
        // =========================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(
            EditCustomerProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            user.FullName = model.FullName;
            user.Email = model.Email;
            user.UserName = model.Email;
            user.PhoneNumber = model.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(
                        string.Empty,
                        error.Description);
                }

                return View(model);
            }

            return RedirectToAction(nameof(Profile));
        }

        // =========================================================
        // ADDRESSES
        // =========================================================

      
        
       [HttpGet]
      public async Task<IActionResult> Addresses()
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var addresses = await _context.Addresses
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.IsDefault)
                .ThenBy(a => a.Label)
                .ToListAsync();

            var model = new SwiftCart.Models.ViewModels.Customer.AddressesViewModel
            {
                Addresses = addresses.Select(a => new SwiftCart.Models.ViewModels.Customer.AddressItemViewModel
                {
                    AddressId = a.AddressId,
                    Label = a.Label,
                    RecipientName = a.RecipientName,
                    PhoneNumber = a.PhoneNumber,
                    AddressLine = a.AddressLine,
                    City = a.City,
                    Region = a.Region,
                    DigitalAddress = a.DigitalAddress,
                    IsDefault = a.IsDefault
                }).ToList()
            };

            return View(model);
        }



        // =========================================================
        // ADD ADDRESS - GET
        // =========================================================

        [HttpGet]
        public IActionResult AddAddress()
        {
            return View();
        }

        // =========================================================
        // ADD ADDRESS - POST
        // =========================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAddress(Address address)
        {
            if (!ModelState.IsValid)
            {
                return View(address);
            }

            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            // Make sure the address belongs to the logged-in customer
            address.UserId = userId;

            // If this address is marked as default,
            // remove the default flag from existing addresses.
            if (address.IsDefault)
            {
                var existingDefaultAddresses = await _context.Addresses
                    .Where(a => a.UserId == userId && a.IsDefault)
                    .ToListAsync();

                foreach (var existingAddress in existingDefaultAddresses)
                {
                    existingAddress.IsDefault = false;
                }
            }

            _context.Addresses.Add(address);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Addresses));
        }

        // =========================================================
        // EDIT ADDRESS - GET
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> EditAddress(int id)
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var address = await _context.Addresses
                .FirstOrDefaultAsync(a =>
                    a.AddressId == id &&
                    a.UserId == userId);

            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // =========================================================
        // EDIT ADDRESS - POST
        // =========================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAddress(
            int id,
            Address address)
        {
            if (id != address.AddressId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(address);
            }

            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            // Only allow the logged-in customer to edit
            // their own address.
            var existingAddress = await _context.Addresses
                .FirstOrDefaultAsync(a =>
                    a.AddressId == id &&
                    a.UserId == userId);

            if (existingAddress == null)
            {
                return NotFound();
            }

            // Update properties using the ACTUAL Address model.
            existingAddress.Label = address.Label;
            existingAddress.RecipientName = address.RecipientName;
            existingAddress.PhoneNumber = address.PhoneNumber;
            existingAddress.AddressLine = address.AddressLine;
            existingAddress.City = address.City;
            existingAddress.Region = address.Region;
            existingAddress.DigitalAddress = address.DigitalAddress;
            existingAddress.IsDefault = address.IsDefault;

            // If this address is being made the default,
            // remove default status from other addresses.
            if (address.IsDefault)
            {
                var otherAddresses = await _context.Addresses
                    .Where(a =>
                        a.UserId == userId &&
                        a.AddressId != id &&
                        a.IsDefault)
                    .ToListAsync();

                foreach (var otherAddress in otherAddresses)
                {
                    otherAddress.IsDefault = false;
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Addresses));
        }

        // =========================================================
        // DELETE ADDRESS
        // =========================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            // Only allow the logged-in customer to delete
            // their own address.
            var address = await _context.Addresses
                .FirstOrDefaultAsync(a =>
                    a.AddressId == id &&
                    a.UserId == userId);

            if (address == null)
            {
                return NotFound();
            }

            _context.Addresses.Remove(address);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Addresses));
        }
    }
}


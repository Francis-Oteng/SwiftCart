using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftCart.Data;
using SwiftCart.Models;
using SwiftCart.Models.ViewModels.Store;

namespace SwiftCart.Controllers
{
    [Authorize]
    public class StoreController : Controller
    {
        private readonly SwiftCartDbContext _context;

        public StoreController(SwiftCartDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // STORE LIST
        // =========================================================

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index(
            string? search,
            string? location)
        {
            var query = _context.Stores
                .Include(s => s.Products)
                .Where(s => s.Status == StoreStatus.Approved)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(s =>
                    s.Name.Contains(search) ||
                    (s.Description != null &&
                     s.Description.Contains(search)));
            }

            if (!string.IsNullOrWhiteSpace(location))
            {
                query = query.Where(s =>
                    s.Location.Contains(location));
            }

            var stores = await query
                .OrderBy(s => s.Name)
                .ToListAsync();

            var model = new StoreListViewModel
            {
                Search = search,
                Location = location,

                Stores = stores.Select(s => new StoreListItemViewModel
                {
                    StoreId = s.StoreId,
                    Name = s.Name,
                    Description = s.Description,
                    Location = s.Location,
                    PhoneNumber = s.PhoneNumber,
                    LogoUrl = s.LogoUrl,
                    IsOpen = s.IsOpen,
                    Status = s.Status,
                    ProductCount = s.Products.Count
                }).ToList()
            };

            return View(model);
        }

        // =========================================================
        // STORE DETAILS
        // =========================================================

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var store = await _context.Stores
                .Include(s => s.Products)
                .FirstOrDefaultAsync(s =>
                    s.StoreId == id &&
                    s.Status == StoreStatus.Approved);

            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        // =========================================================
        // STORE OWNER DASHBOARD
        // =========================================================

        [Authorize(Roles = "StoreOwner")]
        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            var userId = User.FindFirst(
                System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Challenge();
            }

            var store = await _context.Stores
                .Include(s => s.Products)
                .Include(s => s.Orders)
                .FirstOrDefaultAsync(s => s.OwnerId == userId);

            if (store == null)
            {
                ViewBag.Message =
                    "You do not have a store associated with your account.";

                return View();
            }

            return View(store);
        }

        // =========================================================
        // CREATE STORE - GET
        // =========================================================

        [Authorize(Roles = "StoreOwner")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // =========================================================
        // CREATE STORE - POST
        // =========================================================

        [Authorize(Roles = "StoreOwner")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Store model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.FindFirst(
                System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Challenge();
            }

            var existingStore = await _context.Stores
                .FirstOrDefaultAsync(s => s.OwnerId == userId);

            if (existingStore != null)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "You already have a store.");

                return View(model);
            }

            var store = new Store
            {
                Name = model.Name,
                Description = model.Description,
                Location = model.Location,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Website = model.Website,
                LogoUrl = model.LogoUrl,

                OwnerId = userId,

                Status = StoreStatus.Pending,
                IsOpen = false,

                CreatedDate = DateTime.UtcNow
            };

            _context.Stores.Add(store);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Dashboard));
        }

        // =========================================================
        // EDIT STORE - GET
        // =========================================================

        [Authorize(Roles = "StoreOwner")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = User.FindFirst(
                System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Challenge();
            }

            var store = await _context.Stores
                .FirstOrDefaultAsync(s =>
                    s.StoreId == id &&
                    s.OwnerId == userId);

            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        // =========================================================
        // EDIT STORE - POST
        // =========================================================

        [Authorize(Roles = "StoreOwner")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            Store model)
        {
            if (id != model.StoreId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.FindFirst(
                System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Challenge();
            }

            var store = await _context.Stores
                .FirstOrDefaultAsync(s =>
                    s.StoreId == id &&
                    s.OwnerId == userId);

            if (store == null)
            {
                return NotFound();
            }

            store.Name = model.Name;
            store.Description = model.Description;
            store.Location = model.Location;
            store.PhoneNumber = model.PhoneNumber;
            store.Email = model.Email;
            store.Website = model.Website;
            store.LogoUrl = model.LogoUrl;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Dashboard));
        }

        // =========================================================
        // TOGGLE STORE OPEN/CLOSED
        // =========================================================

        [Authorize(Roles = "StoreOwner")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleOpen()
        {
            var userId = User.FindFirst(
                System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Challenge();
            }

            var store = await _context.Stores
                .FirstOrDefaultAsync(s => s.OwnerId == userId);

            if (store == null)
            {
                return NotFound();
            }

            if (store.Status != StoreStatus.Approved)
            {
                TempData["Error"] =
                    "Your store must be approved before it can be opened.";

                return RedirectToAction(nameof(Dashboard));
            }

            store.IsOpen = !store.IsOpen;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Dashboard));
        }

        // =========================================================
        // ADMIN - STORES
        // =========================================================

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            var stores = await _context.Stores
                .Include(s => s.Owner)
                .OrderByDescending(s => s.CreatedDate)
                .ToListAsync();

            return View(stores);
        }

        // =========================================================
        // ADMIN - APPROVE STORE
        // =========================================================

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            var store = await _context.Stores
                .FirstOrDefaultAsync(s => s.StoreId == id);

            if (store == null)
            {
                return NotFound();
            }

            store.Status = StoreStatus.Approved;
            store.ApprovedDate = DateTime.UtcNow;
            store.IsOpen = true;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Manage));
        }

        // =========================================================
        // ADMIN - REJECT STORE
        // =========================================================

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id)
        {
            var store = await _context.Stores
                .FirstOrDefaultAsync(s => s.StoreId == id);

            if (store == null)
            {
                return NotFound();
            }

            store.Status = StoreStatus.Rejected;
            store.ApprovedDate = null;
            store.IsOpen = false;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Manage));
        }

        // =========================================================
        // ADMIN - SUSPEND STORE
        // =========================================================

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Suspend(int id)
        {
            var store = await _context.Stores
                .FirstOrDefaultAsync(s => s.StoreId == id);

            if (store == null)
            {
                return NotFound();
            }

            store.Status = StoreStatus.Suspended;
            store.IsOpen = false;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Manage));
        }
    }
}
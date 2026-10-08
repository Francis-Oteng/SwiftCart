using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftCart.Data;
using SwiftCart.Models;
using SwiftCart.Models.ViewModels.Product;

namespace SwiftCart.Controllers
{
    public class ProductController : Controller
    {
        private readonly SwiftCartDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductController(
            SwiftCartDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // =========================================================
        // PRODUCT LIST
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> Index(
            string? search,
            int? categoryId,
            int? storeId)
        {
            var query = _context.Products
                .Include(p => p.Store)
                .Include(p => p.Category)
                .AsQueryable();

            // Search
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(p =>
                    p.Name.Contains(search) ||
                    (p.Description != null &&
                     p.Description.Contains(search)));
            }

            // Filter by category
            if (categoryId.HasValue)
            {
                query = query.Where(p =>
                    p.CategoryId == categoryId.Value);
            }

            // Filter by store
            if (storeId.HasValue)
            {
                query = query.Where(p =>
                    p.StoreId == storeId.Value);
            }

            var products = await query
                .OrderBy(p => p.Name)
                .ToListAsync();

            // Convert Product entities into ProductListItemViewModel
            var model = new SwiftCart.Models.ViewModels.ProductListViewModel
            {
                Products = products.Select(p => new ProductListItemViewModel
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    AvailableStock = p.AvailableStock,
                    IsAvailable = p.IsAvailable,
                    StoreId = p.StoreId,
                    StoreName = p.Store != null
                        ? p.Store.Name
                        : string.Empty,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category != null
                        ? p.Category.Name
                        : string.Empty
                }).ToList()
            };

            return View(model);
        }

        // =========================================================
        // PRODUCT DETAILS
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products
                .Include(p => p.Store)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // =========================================================
        // CREATE PRODUCT - GET
        // =========================================================

        [Authorize(Roles = "StoreOwner")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // =========================================================
        // CREATE PRODUCT - POST
        // =========================================================

        [Authorize(Roles = "StoreOwner")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var store = await _context.Stores
                .FirstOrDefaultAsync(s => s.OwnerId == userId);

            if (store == null)
                return NotFound();

            product.StoreId = store.StoreId;

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MyProducts));
        }

        // =========================================================
        // EDIT PRODUCT - GET
        // =========================================================

        [Authorize(Roles = "StoreOwner")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var store = await _context.Stores
                .FirstOrDefaultAsync(s => s.OwnerId == userId);

            if (store == null)
                return NotFound();

            var product = await _context.Products
                .FirstOrDefaultAsync(p =>
                    p.ProductId == id &&
                    p.StoreId == store.StoreId);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // =========================================================
        // EDIT PRODUCT - POST
        // =========================================================

        [Authorize(Roles = "StoreOwner")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            Product product)
        {
            if (id != product.ProductId)
                return NotFound();

            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var store = await _context.Stores
                .FirstOrDefaultAsync(s => s.OwnerId == userId);

            if (store == null)
                return NotFound();

            var existingProduct = await _context.Products
                .FirstOrDefaultAsync(p =>
                    p.ProductId == id &&
                    p.StoreId == store.StoreId);

            if (existingProduct == null)
                return NotFound();

            if (!ModelState.IsValid)
                return View(product);

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.AvailableStock = product.AvailableStock;
            existingProduct.IsAvailable = product.IsAvailable;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.ImageUrl = product.ImageUrl;
            existingProduct.Status = product.Status;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MyProducts));
        }

        // =========================================================
        // DELETE PRODUCT
        // =========================================================

        [Authorize(Roles = "StoreOwner")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var store = await _context.Stores
                .FirstOrDefaultAsync(s => s.OwnerId == userId);

            if (store == null)
                return NotFound();

            var product = await _context.Products
                .FirstOrDefaultAsync(p =>
                    p.ProductId == id &&
                    p.StoreId == store.StoreId);

            if (product == null)
                return NotFound();

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MyProducts));
        }

        // =========================================================
        // STORE OWNER'S PRODUCTS
        // =========================================================

        [Authorize(Roles = "StoreOwner")]
        [HttpGet]
        public async Task<IActionResult> MyProducts()
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var store = await _context.Stores
                .FirstOrDefaultAsync(s => s.OwnerId == userId);

            if (store == null)
                return NotFound();

            var products = await _context.Products
                .Include(p => p.Store)
                .Include(p => p.Category)
                .Where(p => p.StoreId == store.StoreId)
                .OrderBy(p => p.Name)
                .ToListAsync();

            // Convert Product entities into ProductListItemViewModel
            var model = new SwiftCart.Models.ViewModels.ProductListViewModel
            {
                Products = products.Select(p => new ProductListItemViewModel
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    AvailableStock = p.AvailableStock,
                    IsAvailable = p.IsAvailable,
                    StoreId = p.StoreId,
                    StoreName = p.Store != null
                        ? p.Store.Name
                        : string.Empty,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category != null
                        ? p.Category.Name
                        : string.Empty
                }).ToList()
            };

            return View(model);
        }

        // =========================================================
        // UPDATE STOCK
        // =========================================================

        [Authorize(Roles = "StoreOwner")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStock(
            int id,
            int quantity)
        {
            if (quantity < 0)
                return BadRequest("Quantity cannot be negative.");

            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var store = await _context.Stores
                .FirstOrDefaultAsync(s => s.OwnerId == userId);

            if (store == null)
                return NotFound();

            var product = await _context.Products
                .FirstOrDefaultAsync(p =>
                    p.ProductId == id &&
                    p.StoreId == store.StoreId);

            if (product == null)
                return NotFound();

            product.AvailableStock = quantity;

            product.IsAvailable = quantity > 0;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MyProducts));
        }

        // =========================================================
        // TOGGLE PRODUCT AVAILABILITY
        // =========================================================

        [Authorize(Roles = "StoreOwner")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleAvailability(int id)
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var store = await _context.Stores
                .FirstOrDefaultAsync(s => s.OwnerId == userId);

            if (store == null)
                return NotFound();

            var product = await _context.Products
                .FirstOrDefaultAsync(p =>
                    p.ProductId == id &&
                    p.StoreId == store.StoreId);

            if (product == null)
                return NotFound();

            if (!product.IsAvailable && product.AvailableStock <= 0)
            {
                product.IsAvailable = false;
            }
            else
            {
                product.IsAvailable = !product.IsAvailable;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MyProducts));
        }
    }
}


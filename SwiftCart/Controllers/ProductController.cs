using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftCart.Data;
using SwiftCart.Models;

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

        public async Task<IActionResult> Index(string? search)
        {
            var query = _context.Products
                .Include(p => p.Store)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(p =>
                    p.Name.Contains(search));
            }

            var products = await query
                .Where(p => p.IsAvailable)
                .ToListAsync();

            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products
                .Include(p => p.Store)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [Authorize(Roles = "StoreOwner")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "StoreOwner")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            var userId = _userManager.GetUserId(User);

            var store = await _context.Stores
                .FirstOrDefaultAsync(s => s.OwnerId == userId);

            if (store == null)
                return NotFound();

            product.StoreId = store.StoreId;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MyProducts));
        }

        [Authorize(Roles = "StoreOwner")]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [Authorize(Roles = "StoreOwner")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            Product product)
        {
            if (id != product.ProductId)
                return NotFound();

            if (!ModelState.IsValid)
                return View(product);

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MyProducts));
        }

        [Authorize(Roles = "StoreOwner")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MyProducts));
        }

        [Authorize(Roles = "StoreOwner")]
        public async Task<IActionResult> MyProducts()
        {
            var userId = _userManager.GetUserId(User);

            var store = await _context.Stores
                .FirstOrDefaultAsync(s => s.OwnerId == userId);

            if (store == null)
                return NotFound();

            var products = await _context.Products
                .Where(p => p.StoreId == store.StoreId)
                .ToListAsync();

            return View(products);
        }

        [Authorize(Roles = "StoreOwner")]
        [HttpPost]
        public async Task<IActionResult> UpdateStock(
            int id,
            int quantity)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            product.AvailableStock = quantity;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MyProducts));
        }

        [Authorize(Roles = "StoreOwner")]
        [HttpPost]
        public async Task<IActionResult> ToggleAvailability(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            product.IsAvailable = !product.IsAvailable;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MyProducts));
        }
    }
}
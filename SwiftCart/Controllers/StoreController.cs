using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftCart.Data;
using SwiftCart.Models;
using SwiftCart.Models.ViewModels.Store;

namespace SwiftCart.Controllers
{
    public class StoreController : Controller
    {
        private readonly SwiftCartDbContext _context;

        public StoreController(SwiftCartDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var stores = await _context.Stores
                .Include(s => s.Products)
                .Where(s => s.Status == StoreStatus.Approved)
                .ToListAsync();

            var model = new StoreListViewModel
            {
                Stores = stores.Select(store => new StoreListItemViewModel
                {
                    StoreId = store.StoreId,
                    Name = store.Name,
                    Description = store.Description,
                    Location = store.Location,
                    PhoneNumber = store.PhoneNumber,
                    LogoUrl = store.LogoUrl,
                    IsOpen = store.IsOpen,
                    Status = store.Status,
                    ProductCount = store.Products?.Count ?? 0
                }).ToList()
            };

            return View(model);
        }
    }
}


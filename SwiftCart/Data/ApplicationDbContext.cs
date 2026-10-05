using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SwiftCart.Models;

namespace SwiftCart.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<CartItem> CartItems => Set<CartItem>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Delivery> Deliveries => Set<Delivery>();
        public DbSet<DeliveryTracking> DeliveryTrackings => Set<DeliveryTracking>();
        public DbSet<Notification> Notifications => Set<Notification>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<Rider> Riders => Set<Rider>();
        public DbSet<Store> Stores => Set<Store>();
    }

    public class SwiftCartDbContext : ApplicationDbContext
    {
        public SwiftCartDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

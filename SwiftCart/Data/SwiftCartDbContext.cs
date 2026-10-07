using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SwiftCart.Models;

namespace SwiftCart.Data
{
    public class SwiftCartDbContext : IdentityDbContext<ApplicationUser>
    {
        public SwiftCartDbContext(DbContextOptions<SwiftCartDbContext> options)
            : base(options)
        {
        }

        // Customer
        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<CartItem> CartItems => Set<CartItem>();

        // Products and Stores
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Store> Stores => Set<Store>();

        // Orders
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        // Delivery
        public DbSet<Delivery> Deliveries => Set<Delivery>();
        public DbSet<DeliveryTracking> DeliveryTrackings => Set<DeliveryTracking>();
        public DbSet<Rider> Riders => Set<Rider>();

        // Payments
        public DbSet<Payment> Payments => Set<Payment>();

        // Reviews and Notifications
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<Notification> Notifications => Set<Notification>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Avoid multiple-cascade-path errors: restrict deletes by default.
                foreach (var fk in entityType.GetForeignKeys())
                {
                    if (!fk.IsOwnership)
                        fk.DeleteBehavior = DeleteBehavior.Restrict;
                }

                foreach (var property in entityType.GetProperties())
                {
                    var type = Nullable.GetUnderlyingType(property.ClrType) ?? property.ClrType;

                    // Money-style columns get a sensible precision.
                    if (type == typeof(decimal))
                    {
                        property.SetPrecision(18);
                        property.SetScale(2);
                    }

                    // Store enums as readable strings, like the JobFinder template.
                    if (type.IsEnum)
                    {
                        property.SetMaxLength(30);
                        var converterType = typeof(Microsoft.EntityFrameworkCore.Storage.ValueConversion.EnumToStringConverter<>)
                            .MakeGenericType(type);
                        property.SetValueConverter(
                            (Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter)
                            Activator.CreateInstance(converterType, new object?[] { null })!);
                    }
                }
            }
        }
    }
}
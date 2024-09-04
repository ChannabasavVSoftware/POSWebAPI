using Microsoft.EntityFrameworkCore;
using POSWebAPI.Repo.Models;

namespace POSWebAPI.Repo
{
    public class POSContext : DbContext
    {
        public POSContext(DbContextOptions<POSContext> options) : base(options) { }

        // dbset
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configure Product-ProductCategory relationship
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductCategory)
                .WithMany(pc => pc.Products)
                .HasForeignKey(p => p.ProductCategoryId);

            // Configure Product-Tax relationship
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Tax)
                .WithMany(t => t.Products)
                .HasForeignKey(p => p.TaxId);

            // Configure State-Country relationship
            modelBuilder.Entity<State>()
                .HasOne(s => s.Country)
                .WithMany(c => c.States)
                .HasForeignKey(s => s.CountryId);

            // Configure City-State relationship
            modelBuilder.Entity<City>()
                .HasOne(c => c.State)
                .WithMany(s => s.Cities)
                .HasForeignKey(c => c.StateId);

            // Configure Address-City relationship
            modelBuilder.Entity<Address>()
                .HasOne(a => a.City)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CityId);

            // Configure User-Role relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            // Configure User-Address relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
                .WithMany(a => a.Users)
                .HasForeignKey(u => u.AddressId);

            // Configure Order-User relationship
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.MobileNumber);

            // Configure Order-Payment relationship
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.PaymentId);

            // Configure OrderDetail-Order relationship
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            // Configure OrderDetail-Product relationship
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductId);

            // Configure OrderDetail-Tax relationship
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Tax)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(od => od.TaxId);



            base.OnModelCreating(modelBuilder);
        }

    }
}

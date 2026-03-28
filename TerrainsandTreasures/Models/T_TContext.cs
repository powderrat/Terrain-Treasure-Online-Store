
using Microsoft.EntityFrameworkCore;
namespace Terrains_Treasures.Models

{
    public class T_TContext : DbContext
    {
        public T_TContext(DbContextOptions<T_TContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //User Table
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "JaneDoe@Yahoo.com",
                    PasswordHash = "NOT_A_REAL_HASH",
                    Address = "123 Main St, Anytown, USA",
                    PhoneNumber = "1234567890",
                    RegistrationDate = new DateTime(2024,01,01,0,0,0, DateTimeKind.Utc)

                }
            );

            //Product Table
            modelBuilder.Entity<Product>().HasData(
                new Product 
                {
                    ProductId = 1,
                    Name = "Forest Tiles",
                    Description = "A set of forest-themed terrain tiles for tabletop gaming.",
                    Price = 55.00M
                }
             );
            //Order Table
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderId = 1,
                    UserId = 1,
                    OrderDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                    TotalAmount = 110.00M,
                    Status = "Processing"
                }
            );
            //Order_Item Table
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    OrderItemId = 1,
                    OrderId = 1,
                    ProductId = 1,
                    Quantity = 2,
                    UnitPrice = 55.00M
                }
            );
            //Payment Table
            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    PaymentId = 1,
                    OrderId = 1,
                    PaymentDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                    Status = "Completed"
                }
            );
            //Shipping Table
            modelBuilder.Entity<Shipment>().HasData(
                new Shipment
                {
                    ShipmentId = 1,
                    OrderId = 1,
                    ShipmentDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                    Carrier = "UPS",
                    TrackingNumber = "1Z999AA10123456784",
                    Status = "Shipped"
                }
            );
            //Inventory Table
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory
                {
                    InventoryId = 1,
                    ProductId = 1,
                    QuantityInStock = 15
                }
            );

        }
    }
}

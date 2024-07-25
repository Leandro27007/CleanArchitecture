using Microsoft.EntityFrameworkCore;
using NorthWind.Entities.POCOEntitites;

namespace NorthWind.Repositories.EFCore.DataContext
{
    public class NorthWindContext : DbContext
    {
        public NorthWindContext(DbContextOptions<NorthWindContext> options) :
            base(options)
        { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Customer
            modelBuilder.Entity<Customer>()
                .Property(c => c.ID)
                .HasMaxLength(5)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(40);
            #endregion
            #region Product
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(40);
            #endregion
            #region Order
            modelBuilder.Entity<Order>()
                .Property(o => o.CustomerID)
                .IsRequired()
                .HasMaxLength(5)
                .IsFixedLength(); //longitud fija

            modelBuilder.Entity<Order>()
                .Property(o => o.ShipAddress)
                .IsRequired()
                .HasMaxLength(60);

            modelBuilder.Entity<Order>()
                .Property(o => o.ShipCity)
                .HasMaxLength(15);

            modelBuilder.Entity<Order>()
                .Property(o => o.ShipCountry)
                .HasMaxLength(15);

            modelBuilder.Entity<Order>()
                .Property(o => o.ShipPostalCode)
                .HasMaxLength(10);
            #endregion
            #region Primary Key
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProductId }); //De esta manera esta compuesta el primary de key de OrderDetail

            modelBuilder.Entity<Order>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(o => o.CustomerID); //Relacion entre ordenes y customer

            modelBuilder.Entity<OrderDetail>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(od => od.ProductId);
            #endregion
            #region Prueba
            modelBuilder.Entity<Product>()
                .HasData(
                new Product { ID = 1, Name = "Chai" },
                new Product { ID = 2, Name = "Chang" },
                new Product { ID = 3, Name = "Anissed Syrup" }
                );

            modelBuilder.Entity<Customer>()
                .HasData(
                new Customer { ID = "ALFKI", Name = "Alfreds F." },
                new Customer { ID = "ANATR", Name = "Ana Trujillo" },
                new Customer { ID = "ANTON", Name = "Antonio Moreno" }
                );
            #endregion

        }
    }
}

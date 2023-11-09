using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eCom.Infrastructure.Persistance.Repositories;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace eCom.Infrastructure.Persistance
{
    public class InventoryDbContext : DbContext
    {

        public InventoryDbContext() : base()
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var ConnectionString = "Data Source=byteslinger.database.windows.net;Initial Catalog=testdata1;User ID=ByteSlinger;Password=qwe123QWE!@#;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrdersProducts>()
                .HasKey(a => new { a.order_id, a.product_id });
        }


    }

}

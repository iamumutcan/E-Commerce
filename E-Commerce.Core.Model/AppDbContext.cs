using E_Commerce.Core.Model.Entity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace E_Commerce.Core.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("Data Source=localhost;Initial Catalog=E-CommerceDb;Integrated Security=True;")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UsersAddress { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<OrderPayment> OrderPayments { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}

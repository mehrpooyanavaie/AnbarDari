using Microsoft.EntityFrameworkCore;
namespace Anbar.Data
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options):base(options)
        {
            
        }
        public DbSet<Models.Item> Items { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Item>().HasData(new Models.Item() {
                Id = 1,
                Name = "نام محصول",
                Price = "قیمت",
                Description="seed data"
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}

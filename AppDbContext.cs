using E_commers_project.Data;
using Microsoft.EntityFrameworkCore;

namespace E_commers_project
{
    public class AppDbContext : DbContext
    {
       
        public AppDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_products>().HasKey(x => new
            {
                x.Productid
                ,
                x.Userid
            });
            modelBuilder.Entity<Users_Sellers>().HasKey(x => new
            {
                x.UserId
                ,
                x.Sellerid
            });

            modelBuilder.Entity<User_products>().HasOne(x=>x.users).WithMany(x=>x.User_products).HasForeignKey(x=>x.Userid);
            modelBuilder.Entity<User_products>().HasOne(x=>x.products).WithMany(x=>x.user_Products).HasForeignKey(x=>x.Productid);
            modelBuilder.Entity<Users_Sellers>().HasOne(x=>x.users).WithMany(x=>x.User_sellers).HasForeignKey(x=>x.UserId);
            modelBuilder.Entity<Users_Sellers>().HasOne(x=>x.sellers).WithMany(x=>x.User_sellers).HasForeignKey(x=>x.Sellerid);
    
        }


        public DbSet<Products> Products { get; set; }
        public DbSet<Users_Sellers> Users_Sellers { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Sellers> Sellers { get; set; }
        public DbSet<User_products> User_products { get; set; }
    }
}

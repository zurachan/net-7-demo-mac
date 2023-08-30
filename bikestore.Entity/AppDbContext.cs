using bikestore.Entity.Auth;
using Microsoft.EntityFrameworkCore;

namespace bikestore.Entity
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FullName = "Hoàng Thái Dương", Address = "Hà Đông", CreatedDate = DateTime.Now },
                new User { Id = 2, FullName = "Trần Phương Thảo", Address = "Long Biên", CreatedDate = DateTime.Now });
            modelBuilder.Entity<Account>().HasData(
                new Account { Id = 1, Username = "duonght", Password = "123456", UserId = 1, CreatedDate = DateTime.Now },
                new Account { Id = 2, Username = "thaotp", Password = "123456", UserId = 2, CreatedDate = DateTime.Now });
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "ADMIN", CreatedDate = DateTime.Now },
                new Role { Id = 2, Name = "USER", CreatedDate = DateTime.Now });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }
    }
}

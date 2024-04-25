using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tazaker.Models;
using Tazaker.ViewModels;

namespace Tazaker.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(){}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(builder);
        }
        public DbSet<Tazaker.ViewModels.ApplicationUserVM> ApplicationUserVM { get; set; } = default!;
        public DbSet<Tazaker.ViewModels.UserLoginVM> UserLoginVM { get; set; } = default!;
        public DbSet<Tazaker.ViewModels.UserRoleVM> UserRoleVM { get; set; } = default!;
    }
}

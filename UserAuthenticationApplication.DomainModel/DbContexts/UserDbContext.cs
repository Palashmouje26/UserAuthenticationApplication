using Microsoft.EntityFrameworkCore;
using UserAuthenticationApplication.DomainModel.Models.UserRegistration;
using UserAuthenticationApplication.Repository.Login;

namespace UserAuthenticationApplication.DomainModel.DbContexts
{
    public class UserDbContext : DbContext
    {

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
        public DbSet<UserRegistration> UserRegistration { get; set; }
        public DbSet<Login> Login { get; set; }

    }
}

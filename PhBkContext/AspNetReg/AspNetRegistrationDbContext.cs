using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PhBkContext.AspNetReg
{
    public class AspNetRegistrationDbContext : IdentityDbContext<IdentityUser>
    {
        public AspNetRegistrationDbContext(DbContextOptions<AspNetRegistrationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}

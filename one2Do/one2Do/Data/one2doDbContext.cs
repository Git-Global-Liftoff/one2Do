using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace one2Do;

public class one2doDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public one2doDbContext(DbContextOptions<one2doDbContext> options) : base(options)
        {
        }
}

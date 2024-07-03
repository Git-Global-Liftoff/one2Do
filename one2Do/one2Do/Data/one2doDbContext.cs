using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using one2Do.Models;
using one2Do.Models.QuoteModels; // Add namespace for Quote model

namespace one2Do
{
    // public class one2doDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    public class one2doDbContext : IdentityDbContext<User>
    {
        public one2doDbContext(DbContextOptions<one2doDbContext> options) : base(options)
        {
        }

        // DbSet property for Quotes table
        public DbSet<Quote> Quotes { get; set; }
    }
}

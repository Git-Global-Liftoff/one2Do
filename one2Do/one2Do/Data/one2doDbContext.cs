using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using one2Do.Models;
using one2Do.Models.QuoteModels; // Add namespace for Quote model
using one2Do.Models.ToDoModels; //Add namespace for ToDoModels

namespace one2Do
{
    // public class one2doDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    public class one2doDbContext : IdentityDbContext<User>
    {
        public one2doDbContext(DbContextOptions<one2doDbContext> options) : base(options)
        {
        }

        // Add DbSet property for each model
        public DbSet<Quote> Quotes { get; set; } //Add DbSet for Quote
        public DbSet<ToDoList> ToDoLists { get; set; } // Add DbSet for ToDoList
        public DbSet<TaskItem> TaskItems { get; set; } // Add DbSet for TaskItem
        public DbSet<ListTemplate> ListTemplates { get; set; }  // Add DbSet for ListTemplate
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using one2Do.Models;
using one2Do.Models.QuoteModels;
using one2Do.Models.ToDoModels;
using one2Do.WeatherModel;

namespace one2Do.Data
{
    public class one2doDbContext : IdentityDbContext<User>
    {
        public one2doDbContext(DbContextOptions<one2doDbContext> options) : base(options)
        {
        }

        public DbSet<Quote> Quotes { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<ListTemplate> ListTemplates { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<ListTemplateCategory> ListTemplateCategories { get; set; } // Join table for the many-to-many relationship
        
        public DbSet<CityNames> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define the many-to-many relationship using an explicit join entity
            modelBuilder.Entity<ListTemplateCategory>()
                .HasKey(ltc => new { ltc.ListTemplateId, ltc.CategoriesId }); // Composite primary key

            modelBuilder.Entity<ListTemplateCategory>()
                .HasOne(ltc => ltc.ListTemplate)
                .WithMany(lt => lt.ListTemplateCategories)
                .HasForeignKey(ltc => ltc.ListTemplateId);

            modelBuilder.Entity<ListTemplateCategory>()
                .HasOne(ltc => ltc.Categories)
                .WithMany(c => c.ListTemplateCategories)
                .HasForeignKey(ltc => ltc.CategoriesId);
        }
    }
}

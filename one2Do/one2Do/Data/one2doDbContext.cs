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
        public DbSet<Category> Categories { get; set; }
        public DbSet<ToDoListCategory> ToDoListCategories { get; set; }
        public DbSet<ListTemplate> ListTemplates { get; set; }

//         public DbSet<Categories> Categories { get; set; }
        public DbSet<ListTemplateCategory> ListTemplateCategories { get; set; } // Join table for the many-to-many relationship
        
        public DbSet<City> Cities { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ToDoListCategory>()
                .HasKey(tlc => new { tlc.ToDoListId, tlc.CategoryId });

            modelBuilder.Entity<ToDoListCategory>()
                .HasOne(tlc => tlc.ToDoList)
                .WithMany(tl => tl.ToDoListCategories)
                .HasForeignKey(tlc => tlc.ToDoListId);

            modelBuilder.Entity<ToDoListCategory>()
                .HasOne(tlc => tlc.Category)
                .WithMany(c => c.ToDoListCategories)
                .HasForeignKey(tlc => tlc.CategoryId);

            modelBuilder.Entity<ListTemplateCategory>()
                .HasKey(ltc => new { ltc.ListTemplateId, ltc.CategoryId });

            modelBuilder.Entity<ListTemplateCategory>()
                .HasOne(ltc => ltc.ListTemplate)
                .WithMany(lt => lt.ListTemplateCategories)
                .HasForeignKey(ltc => ltc.ListTemplateId);

            modelBuilder.Entity<ListTemplateCategory>()
                .HasOne(ltc => ltc.Category)
                .WithMany(c => c.ListTemplateCategories)
                .HasForeignKey(ltc => ltc.CategoryId);

            modelBuilder.Entity<ToDoList>()
                .HasIndex(t => t.UserId);

            modelBuilder.Entity<TaskItem>()
                .HasIndex(ti => ti.ToDoListId);
                
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.Name).IsRequired();

                // Ignore properties that are not mapped to the database
                entity.Ignore(e => e.Temperature);
                entity.Ignore(e => e.Humidity);
                entity.Ignore(e => e.Pressure);
                entity.Ignore(e => e.Wind);
                entity.Ignore(e => e.Weather);
            });
        }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using one2Do.Models;
using one2Do.Models.QuoteModels;
using one2Do.Models.ToDoModels;

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
        public DbSet<ToDoListCategory> ToDoListCategories { get; set; } // Join table for the many-to-many relationship
        public DbSet<ListTemplate> ListTemplates { get; set; } 
        public DbSet<ListTemplateCategory> ListTemplateCategories { get; set; } // Join table for ListTemplates and Categories

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define the many-to-many relationship using an explicit join entity for ToDoList and Category
            modelBuilder.Entity<ToDoListCategory>()
                .HasKey(tlc => new { tlc.ToDoListId, tlc.CategoryId }); // Composite primary key

            modelBuilder.Entity<ToDoListCategory>()
                .HasOne(tlc => tlc.ToDoList)
                .WithMany(tl => tl.ToDoListCategories)
                .HasForeignKey(tlc => tlc.ToDoListId);

            modelBuilder.Entity<ToDoListCategory>()
                .HasOne(tlc => tlc.Category)
                .WithMany(c => c.ToDoListCategories)
                .HasForeignKey(tlc => tlc.CategoryId);

            // Define the many-to-many relationship using an explicit join entity for ListTemplate and Category
            modelBuilder.Entity<ListTemplateCategory>()
                .HasKey(ltc => new { ltc.ListTemplateId, ltc.CategoryId }); // Composite primary key for ListTemplateCategory

            modelBuilder.Entity<ListTemplateCategory>()
                .HasOne(ltc => ltc.ListTemplate)
                .WithMany(lt => lt.ListTemplateCategories)
                .HasForeignKey(ltc => ltc.ListTemplateId);

            modelBuilder.Entity<ListTemplateCategory>()
                .HasOne(ltc => ltc.Category)
                .WithMany(c => c.ListTemplateCategories)
                .HasForeignKey(ltc => ltc.CategoryId);

            // Adding indexes to commonly queried columns
            modelBuilder.Entity<ToDoList>()
                .HasIndex(t => t.UserId); // Index for UserId 

            modelBuilder.Entity<TaskItem>()
                .HasIndex(ti => ti.ToDoListId); // Index for ToDoListId to improve join performance
        }
    }
}

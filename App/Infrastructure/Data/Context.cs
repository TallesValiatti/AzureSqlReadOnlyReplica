using App.Domain.Books;
using App.Domain.Category;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Data
{
    public class Context : DbContext
    {
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Category> Categories => Set<Category>();
        
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Category>()
                .ToTable("Categories");

            modelBuilder.Entity<Book>()
                .ToTable("Books")
                .HasMany(x => x.BookCategories)
                .WithOne(x => x.Book)
                .HasForeignKey(x => x.BookId);
                
            modelBuilder.Entity<BookCategory>()
                .ToTable("BookCategories");
        }
    }
}
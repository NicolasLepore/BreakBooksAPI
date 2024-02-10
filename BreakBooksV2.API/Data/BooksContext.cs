using BreakBooks.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BreakBooks.Data
{
    public class BooksContext : IdentityDbContext<User>
    {
        public BooksContext(DbContextOptions opt) : base(opt) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LibrarySupplier>()
                .HasKey(ls => new { ls.LibraryId, ls.SupplierId });

            modelBuilder.Entity<LibrarySupplier>()
                .HasOne(ls => ls.Library)
                .WithMany(l => l.LibrarySupplier)
                .HasForeignKey(ls => ls.LibraryId);

            modelBuilder.Entity<LibrarySupplier>()
                .HasOne(ls => ls.Supplier)
                .WithMany(s => s.LibrarySupplier)
                .HasForeignKey(ls => ls.SupplierId);

            modelBuilder.Entity<CartBook>()
                .HasKey(cb => new { cb.CartId, cb.BookId });

            modelBuilder.Entity<CartBook>()
                .HasOne(cb => cb.Cart)
                .WithMany(cart => cart.CartBooks)
                .HasForeignKey(cb => cb.CartId);

            modelBuilder.Entity<CartBook>()
                .HasOne(cb => cb.Book)
                .WithMany(book => book.CartBooks)
                .HasForeignKey(cb => cb.BookId);

        }

        public DbSet<Book> Books { get; internal set; }
        public DbSet<Library> Libraries { get; internal set; }
        public DbSet<Supplier> Suppliers { get; internal set; }
        public DbSet<LibrarySupplier> LibrarySuppliers { get; internal set;}
        public DbSet<Cart> Carts { get; internal set; }
        public DbSet<CartBook> CartBooks { get; internal set;}
    }
}
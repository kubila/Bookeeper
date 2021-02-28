using Booky.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booky.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<BookAuthor> BookAuthors { get; set; }

        public DbSet<BookGenre> BookGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // if OnModelCreating exists in the context this statement is mandatory to have, otherwise identity schema migration fails.
            base.OnModelCreating(modelBuilder);

            // configuring Fluent API

            // set a table name using Fluent API
            modelBuilder.Entity<Category>().ToTable("tbl_category");

            // set a column property using Fluent API
            modelBuilder.Entity<Category>().Property(c => c.Name).HasColumnName("CategoryName");

            // here we create a composite key for our pivot table(BookAuthor). this will be created using both Author_Id and Book_Id.
            modelBuilder.Entity<BookAuthor>().HasKey(b => new { b.Author_Id, b.Book_Id });
            // here we create a composite key for our pivot table(BookGenre). this will be created using both Genre_Id and Book_Id.
            modelBuilder.Entity<BookGenre>().HasKey(g => new { g.Genre_Id, g.Book_Id });
        }
    }
}

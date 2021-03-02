using Booky.Contracts;
using Booky.Data;
using Booky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booky.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Authors = new AuthorRepository(_context);
            Books = new BookRepository(_context);
            BookDetails = new BookDetailRepository(_context);
            Categories = new CategoryRepository(_context);
            Genres = new GenreRepository(_context);
            Publishers = new PublisherRepository(_context);
        }

        public IAuthorRepository Authors { get; }

        public IBookRepository Books { get; }

        public IBookDetailRepository BookDetails { get; }

        public ICategoryRepository Categories { get; }

        public IGenreRepository Genres { get; }

        public IPublisherRepository Publishers { get; }


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }


        public async Task Save()
        {          
            await _context.SaveChangesAsync();            
        }
    }
}

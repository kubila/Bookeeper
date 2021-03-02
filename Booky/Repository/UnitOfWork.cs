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

        private IRepositoryBase<Category> _categories;

        private IRepositoryBase<Genre> _genres;

        private IRepositoryBase<Publisher> _publishers;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Authors = new AuthorRepository(_context);
            Books = new BookRepository(_context);
            BookDetails = new BookDetailRepository(_context);
            Categories = new CategoryRepository(_context);
            Genres = new GenreRepository(_context);
        }

        public IAuthorRepository Authors { get; }

        public IBookRepository Books { get; }

        public IBookDetailRepository BookDetails { get; }

        public ICategoryRepository Categories { get; }

        public IGenreRepository Genres { get; }

        public IPublisherRepository Publishers => throw new NotImplementedException();


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

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

        private IRepositoryBase<Author> _authors;

        private IRepositoryBase<Book> _books;

        private IRepositoryBase<BookDetail> _bookDetails;

        private IRepositoryBase<Category> _categories;

        private IRepositoryBase<Genre> _genres;

        private IRepositoryBase<Publisher> _publishers;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }


        public IRepositoryBase<Author> Authors => _authors ??= new RepositoryBase<Author>(_context);

        public IRepositoryBase<Book> Books => _books ??= new RepositoryBase<Book>(_context);

        public IRepositoryBase<BookDetail> BookDetails => _bookDetails ??= new RepositoryBase<BookDetail>(_context);

        public IRepositoryBase<Category> Categories => _categories ??= new RepositoryBase<Category>(_context);

        public IRepositoryBase<Genre> Genres => _genres ??= new RepositoryBase<Genre>(_context);

        public IRepositoryBase<Publisher> Publishers => _publishers ??= new RepositoryBase<Publisher>(_context);

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

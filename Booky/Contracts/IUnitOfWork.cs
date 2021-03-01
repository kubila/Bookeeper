using Booky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booky.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryBase<Author> Authors { get; }

        IRepositoryBase<Book> Books { get; }

        IRepositoryBase<BookDetail> BookDetails { get; }

        IRepositoryBase<Category> Categories { get; }

        IRepositoryBase<Genre> Genres { get; }

        IRepositoryBase<Publisher> Publishers { get; }

        Task Save();
    }
}

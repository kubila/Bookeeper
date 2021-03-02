using Booky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booky.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository Authors { get; }

        IBookRepository Books { get; }

        IBookDetailRepository BookDetails { get; }

        ICategoryRepository Categories { get; }

        IGenreRepository Genres { get; }

        IPublisherRepository Publishers { get; }

        Task Save();
    }
}

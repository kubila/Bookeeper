using Booky.Contracts;
using Booky.Data;
using Booky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booky.Repository
{
    
    public class BookDetailRepository : RepositoryBase<BookDetail>, IBookDetailRepository
    {
        private readonly ApplicationDbContext _context;

        public BookDetailRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}

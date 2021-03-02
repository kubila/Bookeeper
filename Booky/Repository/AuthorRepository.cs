using Booky.Contracts;
using Booky.Data;
using Booky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booky.Repository
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        private readonly ApplicationDbContext _context;
        
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


    }
}

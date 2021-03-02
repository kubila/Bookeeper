using Booky.Contracts;
using Booky.Data;
using Booky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booky.Repository
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        private readonly ApplicationDbContext _context;
        
        public GenreRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


    }
}

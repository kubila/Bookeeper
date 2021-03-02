using Booky.Contracts;
using Booky.Data;
using Booky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booky.Repository
{
    public class PublisherRepository : RepositoryBase<Publisher>, IPublisherRepository
    {
        private readonly ApplicationDbContext _context;
        
        public PublisherRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


    }
}

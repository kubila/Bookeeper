using Booky.Data;
using Booky.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booky.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AuthorController
        public async Task<IActionResult> Index()
        {
            List<Author> authorList = await _context.Authors.ToListAsync();
            
            return View(authorList);
        }

        // GET: AuthorController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(c => c.Author_Id == id);
            return View(author);
        }

        // GET: AuthorController/UpSert
        public async Task<IActionResult> UpSert(int? id)
        {

            var author = new Author();

            if ( id == null ) return View(author);

            author = await _context.Authors.FirstOrDefaultAsync(c => c.Author_Id == id);

            if ( author == null ) return NotFound();

            return View(author);
        
        }

        // POST: AuthorController/UpSert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpSert(Author author, int? id)
        {

            if (ModelState.IsValid)
            {
                if (author.Author_Id == 0 )
                {
                    // create
                    _context.Authors.Add(author);
                } else
                {
                    // update
                   _context.Authors.Update(author);
                }
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(author);
           
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(c => c.Author_Id == id);
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
    }
}

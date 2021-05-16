using Booky.Contracts;
using Booky.Data;
using Booky.Models;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IUnitOfWork _unitOfWork;

        public AuthorController(IUnitOfWork unitOfWork)
        {           
            _unitOfWork = unitOfWork;
        }

        // GET: AuthorController
        public async Task<IActionResult> Index()
        {
            var authors = await _unitOfWork.Authors.FindAll();
            return View(authors);
        }

        // GET: AuthorController/Details/5
        public async Task<IActionResult> Details(int id)
        {            
            var author = await _unitOfWork.Authors.Find(a => a.Author_Id == id);
            return View(author);
        }

        // GET: AuthorController/UpSert
        //[HttpGet("/authors/upsert/{id:int}")]
        public async Task<IActionResult> UpSert(int? id)
        {

            var author = new Author();

            if ( id == null ) return View(author);

            author = await _unitOfWork.Authors.Find(a => a.Author_Id == id);
            if ( author == null ) return NotFound();

            return View(author);
        
        }

        // POST: AuthorController/UpSert
        //[HttpPost("/authors/upsert/{}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpSert(Author author, int? id)
        {

            if (ModelState.IsValid)
            {
                if (author.Author_Id == 0 )
                {
                    // create
                    _unitOfWork.Authors.Create(author);                    
                } else
                {
                    // update
                    _unitOfWork.Authors.Update(author);
                }

                await _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(author);
           
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var author = await _unitOfWork.Authors.Find(a => a.Author_Id == id);
                _unitOfWork.Authors.Delete(author);
                await _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
    }
}

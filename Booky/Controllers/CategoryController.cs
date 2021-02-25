using Booky.Data;
using Booky.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext context)
        {
            _db = context;
        }

        // GET: CategoryController
        public IActionResult Index()
        {
            List<Category> catList = _db.Categories.ToList();

            return View(catList);
        }

        // performs both Insert and Update operations
        public IActionResult UpSert(int? id)
        {
            Category obj = new Category();

            if (id == null)
            {
                return View(obj);
            }

            obj = _db.Categories.FirstOrDefault(c => c.Category_Id == id);

            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert(Category category, int? id)
        {
            
            if(ModelState.IsValid)
            {
               if(category.Category_Id == 0)
                {
                    
                    _db.Categories.Add(category);
                    
                } else
                {
                    _db.Categories.Update(category);                   
                }

                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(category);

        }   
        
       
        public IActionResult Delete(int id)
        {
            try
            {
                var category = _db.Categories.FirstOrDefault(c => c.Category_Id == id);
                _db.Categories.Remove(category);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult CreateMultipleTwo()
        {
            List<Category> catList = new List<Category>();

            for ( int i = 0; i <= 2; i++ )
            {
                
                catList.Add(new Category { Name = Guid.NewGuid().ToString() });
                //_db.Categories.Add(new Category {  Name = Guid.NewGuid().ToString()});
            }

            _db.Categories.AddRange(catList);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultipleFive()
        {
            List<Category> catList = new List<Category>();

            for (int i = 0; i <= 5; i++)
            {
                catList.Add(new Category { Name = Guid.NewGuid().ToString() });
            }

            _db.Categories.AddRange(catList);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}



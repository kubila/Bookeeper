using Booky.Contracts;
using Booky.Data;
using Booky.Models;
using Booky.Repository;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {          
            _unitOfWork = unitOfWork;
        }

        // GET: CategoryController
        public async Task<IActionResult> Index()
        {            
            var catList = await _unitOfWork.Categories.FindAll();

            return View(catList);
        }

        // performs both Insert and Update operations
        public async Task<IActionResult> UpSert(int? id)
        {
            Category obj = new Category();

            if (id == null)
            {
                return View(obj);
            }

            obj = await _unitOfWork.Categories.Find(c => c.Category_Id == id);
                      

            if( obj  == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpSert(Category category, int? id)
        {
            
            if(ModelState.IsValid)
            {
               if(category.Category_Id == 0)
                {
                     _unitOfWork.Categories.Create(category);
                    
                    
                } else
                {
                    _unitOfWork.Categories.Update(category);                                   
                }

                await _unitOfWork.Save();
                                
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }
        
       
        public async Task<IActionResult> Delete(int id)
        {
            try
            {                
                var category = await _unitOfWork.Categories.Find(c => c.Category_Id == id);
                _unitOfWork.Categories.Delete(category);
                await _unitOfWork.Save();
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> CreateMultipleTwo()
        {
            List<Category> catList = new List<Category>();

            for ( int i = 0; i <= 2; i++ )
            {
                
                catList.Add(new Category { Name = Guid.NewGuid().ToString() });                
            }

            _unitOfWork.Categories.AddRange(catList);
            await _unitOfWork.Save();
            
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateMultipleFive()
        {
            List<Category> catList = new List<Category>();

            for (int i = 0; i <= 5; i++)
            {
                catList.Add(new Category { Name = Guid.NewGuid().ToString() });
            }

            _unitOfWork.Categories.AddRange(catList);
            await _unitOfWork.Save();
            
            return RedirectToAction(nameof(Index));
        }


    }
}



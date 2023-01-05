// importing namespaces
using ExampleProject.Data;
using ExampleProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ExampleProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;   
        }

        public IActionResult Index()
        {
            // use IEnumerable<Category> to iterate over the results
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();
            // passing it ot the view, so that we can use it in the view
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            // This is the default method
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            // get data from form submitted by view
            // validate it and add it to the SQL Sever
            if (ModelState.IsValid)
            {
                // Add it to the Categories table in database
                _db.Categories.Add(obj);
                // Save the changes
                _db.SaveChanges();
                // After saving the data, redirect it to the "Index" Page of the Create View
                return RedirectToAction("Index");
            }
            else
            {
                // Return the default Create View
                return View();
            }
        }

        // Adding functionality for Edit function
        public IActionResult Edit(int? id)
        {
            // validate the id
            if (id==0 || id==null)
            {
                return NotFound();
            }
            // get the data based on id
            var category = _db.Categories.Find(id);
            if (category==null)
            {
                // push data to the view
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                // we need to update the existing data
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id==0 || id == null)
            {
                return NotFound();
            }

            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
           // return View(category);
        }
    }

}
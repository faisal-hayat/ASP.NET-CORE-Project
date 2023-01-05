// importing namespaces
using ExampleProject.Data;
using ExampleProject.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
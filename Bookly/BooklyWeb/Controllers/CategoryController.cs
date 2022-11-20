using BooklyWeb.Data;
using BooklyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooklyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _dbContext.Categories.ToList();

            return View(categories);
        }
    }
}

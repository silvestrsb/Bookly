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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name input inside of DisplayOrder field");
            }

            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }

            var categoryFromDb = _dbContext.Categories.Find(id);
            //var categoryFromDb = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            //var categoryFromDb = _dbContext.Categories.SingleOrDefault(c => c.Id == id);

            if(categoryFromDb==null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name input inside of DisplayOrder field");
            }

            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Delete(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }

            var categoryFromDb = _dbContext.Categories.Find(id);
            //var categoryFromDb = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            //var categoryFromDb = _dbContext.Categories.SingleOrDefault(c => c.Id == id);

            if(categoryFromDb==null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name input inside of DisplayOrder field");
            }

            if (ModelState.IsValid)
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(category);
        }

    }
}

using indiereb.Data;
using indiereb.Models;
using Microsoft.AspNetCore.Mvc;

namespace indiereb.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        // Retrieve our categories 
        var objCategoryList = _db.Categories.ToList();
        return View(objCategoryList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
            ModelState.AddModelError("Name", "Name and Display Order cannot be the same");

        if (!ModelState.IsValid) return View();

        _db.Categories.Add(obj);
        _db.SaveChanges();

        TempData["SuccessMessage"] = "Category created successfully";

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int? id)
    {
        if (id is null or 0) return NotFound();

        var categoryFromDatabase = _db.Categories.Find(id);

        if (categoryFromDatabase == null) return NotFound();

        return View(categoryFromDatabase);
    }

    [HttpPost]
    public IActionResult Edit(Category obj)
    {
        if (obj.CategoryId == 0) return NotFound();

        if (!ModelState.IsValid) return View(obj);

        _db.Categories.Update(obj);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(int? id)
    {
        var obj = _db.Categories.Find(id);

        if (obj == null) return NotFound();

        _db.Categories.Remove(obj);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }
}
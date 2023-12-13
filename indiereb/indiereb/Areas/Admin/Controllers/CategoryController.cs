using Indiereb.DataAccess.Repository.IRepository;
using Indiereb.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace indiereb.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        // Retrieve our categories 
        var objCategoryList = _unitOfWork.Category.GetAll().ToList();
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

        _unitOfWork.Category.Add(obj);
        _unitOfWork.Save();

        TempData["SuccessMessage"] = "Category created successfully";

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int? id)
    {
        if (id is null or 0) return NotFound();

        var categoryFromDatabase = _unitOfWork.Category.GetOne(c => c.CategoryId == id);

        if (categoryFromDatabase == null) return NotFound();

        return View(categoryFromDatabase);
    }

    [HttpPost]
    public IActionResult Edit(Category obj)
    {
        if (obj.CategoryId == 0) return NotFound();

        if (!ModelState.IsValid) return View(obj);

        _unitOfWork.Category.Update(obj);
        _unitOfWork.Save();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(int? id)
    {
        var obj = _unitOfWork.Category.GetOne(c => c.CategoryId == id);

        if (obj == null) return NotFound();

        _unitOfWork.Category.Remove(obj);
        _unitOfWork.Save();

        return RedirectToAction("Index");
    }
}
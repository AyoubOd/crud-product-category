using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using tp11.Data.Repositories.Interfaces;
using tp11.Models;

namespace tp11.Controllers;

public class ProductsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        await _unitOfWork.CompleteAsync();
        var products = await _unitOfWork.Products.All();
        return View(products);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.categories = await _unitOfWork.Categories.All();
        ViewBag.action = "Store";
        return View();
    }

    [HttpPost]
    public IActionResult Store(Product product)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Something went wrong");
            return View("Create", product);
        }

        _unitOfWork.Products.Add(product);
        _unitOfWork.CompleteAsync();
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Show(Guid id)
    {
        var product = _unitOfWork.Products.GetById(id);
        ViewBag.categories = await _unitOfWork.Categories.All();
        ViewBag.action = "Update";
        if (product == null) return NotFound();
        return View("Create", product);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Product product)
    {
        Console.WriteLine(product.Id);
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Something went wrong");
            return View("Create", product);
        }

        _unitOfWork.Products.Update(product);
        await _unitOfWork.CompleteAsync();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(Guid id)
    {
        var product = _unitOfWork.Products.GetById(id);
        if (product == null) return NotFound();
        _unitOfWork.Products.Delete(product);
        _unitOfWork.CompleteAsync();
        return RedirectToAction("Index");
    }
}
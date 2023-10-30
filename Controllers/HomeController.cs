using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using products_categories.Models;

namespace products_categories.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        ViewBag.AllProducts = _context.Products.ToList();
        return View();
    }

    [HttpPost]
    [Route("products/create")]
    public IActionResult CreateProduct(Product newProduct)
    {
        if (ModelState.IsValid)
        {
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet]
    [Route("products/showproduct/{ProductId}")]
    public IActionResult ShowProduct(int ProductId)
    {
        Product? OneProduct = _context.Products.FirstOrDefault(p => p.ProductId == ProductId);
        ViewBag.AllCategories = _context.Categories.ToList();
        return View(OneProduct);
    }

    [HttpGet]
    [Route("categories")]
    public IActionResult Categories()
    {
        ViewBag.AllCategories = _context.Categories.ToList();
        return View("Categories");
    }

    [HttpPost]
    [Route("categories/create")]
    public IActionResult CreateCategory(Category newCategory)
    {
        if (ModelState.IsValid)
        {
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("Categories");
        }
        else
        {
            return View("Categories");
        }
    }

    [HttpGet]
    [Route("categories/showcategory/{CategoryId}")]
    public IActionResult ShowCategory(int CategoryId)
    {
        Category? OneCategory = _context.Categories.FirstOrDefault(c => c.CategoryId == CategoryId);
        return View(OneCategory);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

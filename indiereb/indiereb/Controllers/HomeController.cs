using System.Diagnostics;
using Indiereb.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace indiereb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View("DummyAction"); // Custom view name
    }

    public IActionResult Privacy()
    {
        return View();
    }


    public IActionResult DummyAction()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
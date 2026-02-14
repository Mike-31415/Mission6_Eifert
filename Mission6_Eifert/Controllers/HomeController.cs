using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6_Eifert.Models;

namespace Mission6_Eifert.Controllers;

public class HomeController : Controller
{
    private MovieContext _context;
    public HomeController(MovieContext temp) // Constructor
    {
        _context = temp;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    [HttpGet]
    public IActionResult AddMovie()
    {
        return View();
    }

    // Code used to save a move to the database then return to the home page
    [HttpPost]
    public IActionResult AddMovie(Movie movie)
    {
        _context.Movies.Add(movie); // Add record to the database
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
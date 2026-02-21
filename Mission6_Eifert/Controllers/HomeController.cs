using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
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
    
    public IActionResult MovieList()
    {
        var movies = _context.Movies
            .Include(m => m.Category)
            .OrderBy(m => m.Title)
            .ToList();
        return View(movies);
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var movie = _context.Movies
            .Include(m => m.Category)
            .FirstOrDefault(m => m.MovieId == id);

        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();

        return RedirectToAction("MovieList");
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movie = _context.Movies
            .Include(m => m.Category)
            .FirstOrDefault(m => m.MovieId == id);

        if (movie == null)
        {
            return NotFound();
        }

        ViewBag.Categories = _context.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();

        return View(movie);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Update(movie);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        ViewBag.Categories = _context.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();

        return View(movie);
    }



}
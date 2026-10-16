using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Joo_Jeana_HW3.Models;
using Joo_Jeana_HW3.DAL;
using Joo_Jeana_HW3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

#pragma warning restore format

namespace Joo_Jeana_HW3.Controllers;

public class HomeController : Controller
{
    public IActionResult Index(String SearchString)
    {
        var query = from b in _context.Books select b;
        if (String.IsNullOrEmpty(SearchString) == false)
        {
            query = query.Where(b => b.Title.Contains(SearchString) || b.Description.Contains(SearchString) || b.Author.Contains(SearchString));
        }
        List<Book> SelectedBooks = query.Include(b => b.Genre).ToList();
        ViewBag.SelectedBooks = SelectedBooks.Count();
        ViewBag.AllBooks = _context.Books.Count();
        return View(SelectedBooks.OrderBy(s => s.Title));
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

    private AppDbContext _context;
    public HomeController(AppDbContext dbContext)
    {
        _context = dbContext;
    }
    public IActionResult Details (int? id)//id is the id of the book you want to see
    {
        if (id == null) //BookID not specified
        {
           //user did not specify a BookID – take them to the error view
           return View("Error", new String[] { "BookID not specified - which book do you want to view?" });
        }
        //look up the book in the database based on the id; be sure to include the genre
        Book book = _context.Books.Include(b => b.Genre)
                                  .FirstOrDefault(b => b.BookID == id);

        if (book == null) //No book with this id exists in the database
        {
            //there is not a book with this id in the database – show the user an error view
            return View("Error", new String[] { "Book not found in database" });
        }
        //if code gets this far, all is well – display the details
        return View(book);
    }
    // Gets page when clicking a link to search
    public IActionResult DetailedSearch()
    {
    // Fills ViewBag, dropdown has data when the page loads
        ViewBag.AllGenres = GetAllGenres(); 
        return View();
    }
    private SelectList GetAllGenres()
    {
        List<Genre> genreList = _context.Genres.OrderBy(g => g.GenreName).ToList();
            Genre allGenres = new Genre { GenreID = 0, GenreName = "All Genres" };
            genreList.Insert(0, allGenres);
    return new SelectList(genreList, "GenreID", "GenreName");
    }
    public IActionResult DisplaySearchResults(SearchViewModel svm)
    {
        var query = _context.Books.Include(b => b.Genre).AsQueryable();
        if (!string.IsNullOrEmpty(svm.SearchName))
        {
            query = query.Where(b => b.Title.Contains(svm.SearchName) || b.Author.Contains(svm.SearchName));
        }
        if (!string.IsNullOrEmpty(svm.SearchDescription))
        {
            query = query.Where(b => b.Description.Contains(svm.SearchDescription));
        }
        if (svm.SelectedGenreID != 0)
        {
            query = query.Where(b => b.Genre.GenreID == svm.SelectedGenreID);
        }
        if (svm.SearchFormat != null)
        {
            query = query.Where(b => b.BookFormat == svm.SearchFormat);
        }
        if (svm.SearchPrice != null)
        {
            if (svm.PriceType == "GreaterThan")
            {
                query = query.Where(b => b.Price >= svm.SearchPrice);
            }
            else
            {
                query = query.Where(b => b.Price <= svm.SearchPrice);
            }
        }
        if (svm.SearchDate != null)
        {
            query = query.Where(b => b.PublishedDate >= svm.SearchDate); 
        }
        List<Book> SelectedBooks = query.OrderBy(s => s.Title).ToList();
        ViewBag.SelectedBooks = SelectedBooks.Count();
        ViewBag.AllBooks = _context.Books.Count();
        return View("Index", SelectedBooks.OrderBy(b => b.Title));
    }
}
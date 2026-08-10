using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

public class BooksController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
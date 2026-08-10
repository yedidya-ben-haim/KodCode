using Microsoft.AspNetCore.Mvc;

namespace UniversityApi.Controllers;

public class tudentsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers;

public class Products : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
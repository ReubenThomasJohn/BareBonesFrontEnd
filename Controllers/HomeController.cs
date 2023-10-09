using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudentFrontEnd.Models;

namespace StudentFrontEnd.Controllers;

public class HomeController : Controller
{
    private readonly ApiService _apiService;

    public HomeController(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> Index()
    {
        var studentData = await _apiService.GetResourceDataAsync("students/");
        return View(studentData);
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

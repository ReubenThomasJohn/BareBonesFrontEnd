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

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var studentData = await _apiService.GetResourceDataAsync("students/");
        return View(studentData);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Student student)
    {
        // Make a POST request to create a new student
        await _apiService.PostDataAsync("/api/students", student);

        // Handle the response as needed (e.g., redirect to a different page)
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var endpoint = $"/students/{id}";
        await _apiService.DeleteDataAsync(endpoint);

        // Handle the response as needed (e.g., redirect to a different page)
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var student = await _apiService.GetResourceDataAsync($"students/{id}");
        if (student != null)
        {
            return View(student);
        }
        return View(null);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Student updatedStudent)
    {
        var endpoint = $"/api/students/{id}";
        await _apiService.UpdateDataAsync(endpoint, updatedStudent);
        return RedirectToAction("Index");
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

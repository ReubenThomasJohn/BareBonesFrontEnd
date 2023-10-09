using System.Diagnostics;
using BareBonesFrontEnd.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentFrontEnd.Models;
using System.Net.Http.Headers;

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
    public async Task<IActionResult> Create(CreateStudentRequest student)
    {
        var json = JsonConvert.SerializeObject(student);
        // Make a POST request to create a new student
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        await _apiService.PostDataAsync("/students", content);
        // Handle the response as needed (e.g., redirect to a different page)
        return RedirectToAction("Index");
    }

    [HttpGet]
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
        var student = await _apiService.GetOneResourceDataAsync($"students/{id}");
        if (student != null)
        {
            return View(student);
        }
        return View(null);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Student updatedStudent)
    {
        var endpoint = $"/students/{updatedStudent.Id}";
        System.Console.WriteLine(endpoint);
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

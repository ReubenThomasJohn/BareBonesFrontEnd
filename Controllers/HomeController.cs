using System.Diagnostics;
using BareBonesFrontEnd.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentFrontEnd.Models;
using System.Net.Http.Headers;
using StudentApi.Repositories;

namespace StudentFrontEnd.Controllers;

public class HomeController : Controller
{
    private readonly IStudentsRepository _repository;

    public HomeController(IStudentsRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var studentData = await _repository.GetAllAsync();
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
        await _repository.CreateAsync(student);
        // Handle the response as needed (e.g., redirect to a different page)
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);

        // Handle the response as needed (e.g., redirect to a different page)
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var student = await _repository.GetAsync(id);
        if (student != null)
        {
            return View(student);
        }
        return View(null);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UpdateStudentRequest updatedStudent)
    {
        await _repository.UpdateAsync(updatedStudent);
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

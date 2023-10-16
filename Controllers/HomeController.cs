using System.Diagnostics;
using BareBonesFrontEnd.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Models;
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
        var studentsData = await _repository.GetAllAsync();
        // var studentsDataWithStateName = new List<StudentWithStateName>();

        // foreach (var studentData in studentsData)
        // {
        //     var studentDataWithStateName = new StudentWithStateName
        //     {
        //         Id = studentData.Id,
        //         Name = studentData.Name,
        //         Rank = studentData.Rank,
        //         StateName = studentData.StateName
        //     };
        //     studentsDataWithStateName.Add(studentDataWithStateName);
        // }

        return View(studentsData);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var states = _repository.GetStates();
        var StudentWithAllStateNames = new CreateStudentViewModel
        {
            Name = "Enter Name Here",
            States = states,
            SelectedStateId = 1
        };
        return View(StudentWithAllStateNames);
    }

    // [HttpPost]
    // public async Task<IActionResult> Create(CreateStudentViewModel createdStudent)
    // {
    //     var student = new Student
    //     {
    //         Name = createdStudent.Name,
    //         Rank = createdStudent.Rank,
    //         StateId = createdStudent.SelectedStateId
    //     };
    //     await _repository.CreateAsync(student);
    //     // Handle the response as needed (e.g., redirect to a different page)
    //     return RedirectToAction("Index");
    // }

    [HttpPost]
    public async Task<IActionResult> Create(CreateStudentViewModel createdStudent)
    {
        if (ModelState.IsValid)
        {
            var student = new Student
            {
                Name = createdStudent.Name,
                Rank = createdStudent.Rank,
                StateId = createdStudent.SelectedStateId
            };
            await _repository.CreateAsync(student);
            // Handle the response as needed (e.g., redirect to a different page)
            return RedirectToAction("Index");
        }
        // If ModelState is not valid, return to the form with validation errors
        return View(createdStudent);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);

        // Handle the response as needed (e.g., redirect to a different page)
        return RedirectToAction("Index");
    }

    // [HttpGet]
    // public async Task<IActionResult> Edit(int id)
    // {
    //     var student = await _repository.GetAsync(id);

    //     if (student != null)
    //     {
    //         return View(student);
    //     }
    //     return View(null);
    // }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var student = await _repository.GetAsync(id);
        var states = _repository.GetStates();
        var StudentWithAllStateNames = new UpdateStudentViewModel
        {
            Id = id,
            Name = student.Name,
            Rank = student.Rank,
            States = states,
            SelectedStateId = student.StateId
        };
        return View(StudentWithAllStateNames);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UpdateStudentViewModel updatedStudent)
    {
        var student = new Student
        {
            Id = updatedStudent.Id,
            Name = updatedStudent.Name,
            Rank = updatedStudent.Rank,
            StateId = updatedStudent.SelectedStateId
        };
        await _repository.UpdateAsync(student);
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

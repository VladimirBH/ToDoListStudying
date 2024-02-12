using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList.DataAccess.Repositories;
using ToDoList.Models;

namespace ToDoList.Controllers;

public class HomeController : Controller
{
    ToDoElementRepository repository;

    public HomeController(ToDoElementRepository context)
    {
        repository = context;
    }

    public IActionResult Index()
    {
        return View(repository.GetAll().ToList());
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

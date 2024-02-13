using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList.DataAccess.Contracts;
using ToDoList.Models;

namespace ToDoList.Controllers;

public class HomeController : Controller
{
    private readonly IToDoElementRepository _iToDoElementRepository;

    public HomeController(IToDoElementRepository context)
    {
        _iToDoElementRepository = context;
    }

    public IActionResult Index()
    {
        return View(_iToDoElementRepository.GetAll().ToList());
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

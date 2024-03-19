using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList.DataAccess.Contracts;
using ToDoList.DataAccess.Implementations.Entities;
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
    
    [HttpGet, ActionName("Delete")]
    public IActionResult DeleteElement(int id)
    {
        _iToDoElementRepository.Remove(_iToDoElementRepository.GetById(id));
        _iToDoElementRepository.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult AddElement(string textElement)
    {     
        var newToDoElement = new ToDoElement(textElement);
        _iToDoElementRepository.Add(newToDoElement);
        _iToDoElementRepository.SaveChanges();
        return PartialView("TodoElementList", _iToDoElementRepository.GetAll().ToList());
    }

    [HttpGet, ActionName("Finish")]
    public IActionResult FinishElement(int id)
    {
        var changedToDoElement = _iToDoElementRepository.GetById(id);
        changedToDoElement.Completed = true;
        _iToDoElementRepository.Update(changedToDoElement);
        _iToDoElementRepository.SaveChanges();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

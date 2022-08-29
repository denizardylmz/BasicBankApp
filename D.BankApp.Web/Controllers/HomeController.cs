using System.Diagnostics;
using D.BankApp.Web.Datas.Context;
using Microsoft.AspNetCore.Mvc;
using D.BankApp.Web.Models;
using D.BankApp.Web.Repositories;
using System.Linq;
using D.BankApp.Web.Datas.Entities;
using D.BankApp.Web.Mapping;
using D.BankApp.Web.Repositories.Repositories;

namespace D.BankApp.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepository<ApplicationUser> _repository;
    private readonly IUserMapper _mapping;

    public HomeController(ILogger<HomeController> logger, IRepository<ApplicationUser> repository, IUserMapper mapping)
    {
        _logger = logger;
        _repository = repository;
        _mapping = mapping;
    }

    public async Task<IActionResult> Index()
    {
        //get datas from repo
        var datas =  _repository.GetAll().ToList();
        
        //Mapping datas to viewModel data
        var viewDatas = _mapping.MapToListOfUserList(datas);
        
        return View(viewDatas);
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
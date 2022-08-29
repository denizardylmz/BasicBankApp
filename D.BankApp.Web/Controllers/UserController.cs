using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D.BankApp.Web.Datas.Entities;
using D.BankApp.Web.Datas.UnitOfWorks;
using D.BankApp.Web.Models;
using D.BankApp.Web.Repositories;
using D.BankApp.Web.Repositories.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace D.BankApp.Web.Controllers
{
    public class UserController : Controller
    {
        private IUow _uow;
        private readonly IUserMapper _mapper;


        public UserController(IUserMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }


        public async Task<IActionResult> Index([FromRoute]string id)
        {
            var user = await _uow.GetRepository<ApplicationUser>().GetAll().Include(x => x.Accounts).FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            UserDetailModel userDetails = _mapper.MapToUserDetailModel(user);
            return View(userDetails);
        }
        
        public async Task<IActionResult> Delete(string id)
        {
            var account = await _uow.GetRepository<Account>().GetByIdAsync(id);
            var userId = account.ApplicationUserId;
            await _uow.GetRepository<Account>().Delete(id);
            await _uow.SaveAsync();
            return RedirectToAction("Index","User", new {id = userId});
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateModel model)
        {
            var user = _mapper.MapCreateModelToApplicationUser(model);

            await _uow.GetRepository<ApplicationUser>().CreateAsync(user);
            await _uow.SaveAsync();
            
            return RedirectToAction("Index" ,"Home");
        }
    }
}
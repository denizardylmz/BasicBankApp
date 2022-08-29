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
using Microsoft.EntityFrameworkCore.Storage;

namespace D.BankApp.Web.Controllers
{
    public class UserController : Controller
    {
        private IUow2 _uow2;
        private readonly IUserMapper _mapper;


        public UserController(IUserMapper mapper, IUow2 uow2)
        {
            _mapper = mapper;
            _uow2 = uow2;
        }


        public async Task<IActionResult> Index([FromRoute]string id)
        {
            var user = await _uow2.GetRepository<ApplicationUser>().GetAll().Include(x => x.Accounts).FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            UserDetailModel userDetails = _mapper.MapToUserDetailModel(user);
            return View(userDetails);
        }
        
        public async Task<IActionResult> Delete(string id)
        {
            var account = await _uow2.GetRepository<Account>().GetByIdAsync(id);
            var userId = account.ApplicationUserId;
            using (IDbContextTransaction transaction = _uow2.beginTransaction())
            {
                await _uow2.GetRepository<Account>().Delete(id);
                await transaction.CommitAsync();
                await _uow2.SaveAsync();
            }
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

            using (IDbContextTransaction transaction = _uow2.beginTransaction())
            {
                await _uow2.GetRepository<ApplicationUser>().CreateAsync(user);
                await transaction.CommitAsync();
                await _uow2.SaveAsync();

            }
            
            return RedirectToAction("Index" ,"Home");
        }
    }
}
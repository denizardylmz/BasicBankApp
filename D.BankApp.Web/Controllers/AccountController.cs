using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D.BankApp.Web.Datas.Context;
using D.BankApp.Web.Datas.Entities;
using D.BankApp.Web.Datas.UnitOfWorks;
using D.BankApp.Web.Models;
using D.BankApp.Web.Repositories;
using D.BankApp.Web.Repositories.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace D.BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserMapper _userMapper;
        private readonly IAccountMapper _accountMapper;
        private readonly IUow2 _uow2;


        public AccountController(IUserMapper userMapper, IAccountMapper accountMapper, IUow2 uow2)
        {
            _userMapper = userMapper;
            _accountMapper = accountMapper;
            _uow2 = uow2;
        }

        [HttpGet]
        public async Task<IActionResult> Create(string id)
        {
            var user = await _uow2.GetRepository<ApplicationUser>().GetByIdAsync(id);
            var viewUserData = _userMapper.MapToUserList(user);
            return View(viewUserData);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountCreateModel model)
        {
            var account = _accountMapper.MapToAccount(model);
            using (IDbContextTransaction transaction = _uow2.beginTransaction())
            {
                await _uow2.GetRepository<Account>().CreateAsync(account);
                await transaction.CommitAsync();
                await _uow2.SaveAsync();
            }
            //await _uow.GetRepository<Account>().CreateAsync(account);
             //await _uow.SaveAsync();
            return RedirectToAction("index", "Home");
        }

        public async Task<IActionResult> SendMoney(string Id)
        {
            var accounts = _uow2.GetRepository<Account>().GetAll().Where(x => x.Id.ToString() != Id).ToList();

            var sender = await _uow2.GetRepository<Account>().GetByIdAsync(Id);
            ViewBag.Sender = sender;

            var list = accounts.Select(account => new AccountListModel()
            {
                Id = account.Id,
                AccountNumber = account.AccountNumber,
                Balance = account.Balance
            }).ToList();
            
            return View(list);
        }


        public async Task<IActionResult> SendMoneyHandle(AccountSendMoneyModel model)
        {
            var senderAccount = await _uow2.GetRepository<Account>().GetByIdAsync(model.SenderAccount);
            var accountToSendMoney = await _uow2.GetRepository<Account>().GetByIdAsync(model.Selection);
            using (IDbContextTransaction transaction = _uow2.beginTransaction()){
                if (model.Amount <= senderAccount.Balance)
                {
                    accountToSendMoney.Balance += model.Amount;
                    senderAccount.Balance -= model.Amount;
                    await transaction.CommitAsync();
                    await _uow2.SaveAsync();
                }
            }
            
            return RedirectToAction("Index", "Home");
        }

    }
}
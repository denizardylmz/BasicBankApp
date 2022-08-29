using D.BankApp.Web.Datas.Entities;
using D.BankApp.Web.Models;
using D.BankApp.Web.Repositories;

namespace D.BankApp.Web.Mapping;

public class AccountMapper : IAccountMapper
{
    public Account MapToAccount(AccountCreateModel model)
    {
        return new Account()
        {
            Id = new Guid(),
            Balance = model.Balance,
            AccountNumber = model.AccountNumber,
            ApplicationUserId = model.ApplicationUserId
        };
    }
}
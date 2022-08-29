using D.BankApp.Web.Datas.Entities;
using D.BankApp.Web.Models;

namespace D.BankApp.Web.Repositories;

public interface IAccountMapper
{
    public Account MapToAccount(AccountCreateModel model);
}
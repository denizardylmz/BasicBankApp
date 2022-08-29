using D.BankApp.Web.Datas.Entities;

namespace D.BankApp.Web.Models;

public class UserDetailModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<Account> Accounts { get; set; }
}
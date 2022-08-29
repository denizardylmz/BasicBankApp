using D.BankApp.Web.Datas.Entities.Common;

namespace D.BankApp.Web.Datas.Entities;

public class ApplicationUser : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<Account> Accounts { get; set; }
}
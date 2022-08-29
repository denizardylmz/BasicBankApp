using D.BankApp.Web.Datas.Entities.Common;
namespace D.BankApp.Web.Datas.Entities;


public class Account : BaseEntity
{

    public decimal Balance { get; set; }
    
    public int AccountNumber { get; set; }
    
    public Guid ApplicationUserId { get; set; }
    
    public ApplicationUser ApplicationUser { get; set; }
}
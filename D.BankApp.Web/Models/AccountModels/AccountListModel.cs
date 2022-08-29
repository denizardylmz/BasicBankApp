namespace D.BankApp.Web.Models;

public class AccountListModel
{
    public Guid Id { get; set; }
    
    public decimal Balance { get; set; }
    
    public int AccountNumber { get; set; }
}
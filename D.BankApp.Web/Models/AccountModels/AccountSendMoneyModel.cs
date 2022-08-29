namespace D.BankApp.Web.Models;

public class AccountSendMoneyModel
{
    public string SenderAccount { get; set; }
    public decimal Amount { get; set; }
    public string Selection { get; set; }
}
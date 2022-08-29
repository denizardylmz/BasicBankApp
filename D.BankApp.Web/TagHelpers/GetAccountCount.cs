using D.BankApp.Web.Datas.Context;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace D.BankApp.Web.TagHelpers;

[HtmlTargetElement("getAccountCount")]
public class GetAccountCount : TagHelper
{
    public Guid UserId { get; set; }
    private readonly BankContext _context;

    public GetAccountCount(BankContext context)
    {
        _context = context;
    }
    
    
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var accountCount = _context.Accounts.Count(x => x.ApplicationUserId == UserId);
        var html = $"<span class='badge bg-info'> {accountCount} </span>";
        
        output.Content.SetHtmlContent(html);
        base.Process(context, output);
    }
}
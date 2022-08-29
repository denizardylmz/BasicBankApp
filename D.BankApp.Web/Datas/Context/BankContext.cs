using D.BankApp.Web.Datas.Entities;
using D.BankApp.Web.Datas.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace D.BankApp.Web.Datas.Context;

public class BankContext : DbContext
{
    public BankContext(DbContextOptions<BankContext> options) : base(options) {}

    public DbSet<Account> Accounts { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ApplicationUserConfigurations());
        modelBuilder.ApplyConfiguration(new AccountConfigurations());
        
        base.OnModelCreating(modelBuilder);
    }


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        
        return base.SaveChangesAsync(cancellationToken);
    }
}
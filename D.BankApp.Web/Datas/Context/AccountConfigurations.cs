using D.BankApp.Web.Datas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D.BankApp.Web.Datas.Context;

public class AccountConfigurations : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.Property(x => x.AccountNumber).IsRequired();
        builder.Property(x => x.Balance).HasColumnType("decimal(18,4)");
        builder.Property(x => x.Balance).IsRequired();
    }
}
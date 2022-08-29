using D.BankApp.Web.Datas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D.BankApp.Web.Datas.Context;

public class ApplicationUserConfigurations : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Surname).HasMaxLength(100);
        builder.Property(x => x.Name).IsRequired();

        builder.HasMany(x => x.Accounts).WithOne(x => x.ApplicationUser)
            .HasForeignKey(x => x.ApplicationUserId);

    }
}
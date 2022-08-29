using D.BankApp.Web.Datas.Entities.Common;
using D.BankApp.Web.Repositories.Repositories;

namespace D.BankApp.Web.Datas.UnitOfWorks;

public interface IUow
{
    IRepository<T> GetRepository<T>() where T : BaseEntity, new();
    public Task<int> SaveAsync();
}
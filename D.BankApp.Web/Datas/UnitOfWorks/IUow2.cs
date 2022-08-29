using D.BankApp.Web.Datas.Entities.Common;
using D.BankApp.Web.Repositories.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace D.BankApp.Web.Datas.UnitOfWorks;

public interface IUow2 : IDisposable
{
    IDbContextTransaction beginTransaction();
    IRepository<T> GetRepository<T>() where T : BaseEntity;

    public Task<int> SaveAsync();
}
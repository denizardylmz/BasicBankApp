using D.BankApp.Web.Datas.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace D.BankApp.Web.Repositories.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    public DbSet<T> Table { get; }
    public IQueryable<T> GetAll();
    public Task<T?> GetByIdAsync(string Id);
    public Task<bool> CreateAsync(T model);
    public  Task<bool> Delete(string id);

}
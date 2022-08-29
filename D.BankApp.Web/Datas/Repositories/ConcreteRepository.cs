using D.BankApp.Web.Datas.Context;
using D.BankApp.Web.Datas.Entities.Common;
using D.BankApp.Web.Datas.UnitOfWorks;
using D.BankApp.Web.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;

namespace D.BankApp.Web.Repositories;

public class ConcreteRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly BankContext _context;

    public ConcreteRepository(BankContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll()
    {
        return Table.AsQueryable();
    }

    public async Task<T?> GetByIdAsync(string Id)
    {
        return await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(Id));
    }

    public async Task<bool> CreateAsync(T model)
    {
        var entity = await Table.AddAsync(model);

        return entity.State == EntityState.Added;
    }
    
    public async Task<bool> Delete(string id)
    {
        EntityEntry<T> entry = Table.Remove(await GetByIdAsync(id));
        return entry.State == EntityState.Deleted;
    }


}
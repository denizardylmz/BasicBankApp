using D.BankApp.Web.Datas.Context;
using D.BankApp.Web.Datas.Entities.Common;
using D.BankApp.Web.Repositories;
using D.BankApp.Web.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace D.BankApp.Web.Datas.UnitOfWorks;

public class Uow2 : IUow2
{
    private readonly BankContext _context;
    
    
    public Uow2(BankContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public IDbContextTransaction beginTransaction()
    {
        return _context.Database.BeginTransaction();
    }

    public IRepository<T> GetRepository<T>() where T : BaseEntity
    {
        return new ConcreteRepository<T>(_context);
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
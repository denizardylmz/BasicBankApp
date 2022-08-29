using D.BankApp.Web.Datas.Context;
using D.BankApp.Web.Datas.Entities.Common;
using D.BankApp.Web.Repositories;
using D.BankApp.Web.Repositories.Repositories;

namespace D.BankApp.Web.Datas.UnitOfWorks;

public class Uow : IUow
{
    private readonly BankContext _context;

    public Uow(BankContext context)
    {
        _context = context;
    }
    
    public IRepository<T> GetRepository<T>() where T : BaseEntity, new()
    {
        return new ConcreteRepository<T>(_context);
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}

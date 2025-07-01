
using DisplayDataMVC_ORM.DAL;
using Microsoft.EntityFrameworkCore;

namespace DisplayDataMVC_ORM.Repository;

public class CommonRepository<T> : ICommonRepository<T> where T : class
{
    private readonly CustumerDbContext _context;

    public CommonRepository(CustumerDbContext context)
    {
        _context = context;
    }

    

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetDetailsAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<int> InsertAsync(T item)
    {
        await _context.Set<T>().AddAsync(item);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T item)
    {
         _context.Entry(item).State = EntityState.Modified;

        return await _context.SaveChangesAsync();
    }
    public async Task<int> DeleteAsync(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if(entity == null)
        {
            return 0;
        }
        else
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }
    }
}

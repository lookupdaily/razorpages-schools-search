using Microsoft.EntityFrameworkCore;
using SchoolPerformanceTablesMock.Data;
using SchoolPerformanceTablesMock.Services.Interfaces;

namespace SchoolPerformanceTablesMock.Services;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly SchoolPerformanceTablesMockContext _context;

    public Repository(SchoolPerformanceTablesMockContext context)
    {
        _context = context;
    }

    public async Task<IList<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetById(int? id) => await _context.Set<T>().FindAsync(id);

    public async Task CreateAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _context.Add(entity);
        await _context.SaveChangesAsync();
    }
    
    
}
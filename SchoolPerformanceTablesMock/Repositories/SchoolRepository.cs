using System.Data.Entity;
using SchoolPerformanceTablesMock.Data;
using SchoolPerformanceTablesMock.Models;
using SchoolPerformanceTablesMock.Repositories.Interfaces;

namespace SchoolPerformanceTablesMock.Repositories;

public class SchoolRepository : ISchoolRepository
{
    private readonly SchoolPerformanceTablesMockContext _schoolContext;
    public SchoolRepository(SchoolPerformanceTablesMockContext context)
    {
        _schoolContext = context;
    }
    
    public IEnumerable<School> GetAll()
    {
        return _schoolContext.School.ToArray();
    }
    
    public async Task<School?> GetById(int? id) => await _schoolContext.School.FindAsync(id);
    
    public IEnumerable<School> GetByNameOrUrn(string nameOrUrn)
    {
        var result = _schoolContext.School
            .Where(s => s.Name != null && s.Name.ToLower().Contains(nameOrUrn.ToLower()));
        return result.ToArray();
    }
    
    public async Task CreateAsync(School entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _schoolContext.School.Add(entity);
        await _schoolContext.SaveChangesAsync();
    }
}
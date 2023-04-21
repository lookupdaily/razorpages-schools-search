using SchoolPerformanceTablesMock.Models;

namespace SchoolPerformanceTablesMock.Repositories.Interfaces;

public interface ISchoolRepository
{
    IEnumerable<School> GetAll();
    Task<School?> GetById(int? id);
    Task CreateAsync(School school);
    IEnumerable<School> GetByNameOrUrn(string nameOrUrn);
}
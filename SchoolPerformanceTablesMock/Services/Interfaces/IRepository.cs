using SchoolPerformanceTablesMock.Models;

namespace SchoolPerformanceTablesMock.Services.Interfaces;

public interface IRepository<T> where T : class
{
    Task<IList<T>> GetAll();

    Task<T?> GetById(int? id);
    Task CreateAsync(T entity);
}
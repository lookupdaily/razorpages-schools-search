using Microsoft.EntityFrameworkCore;
using SchoolPerformanceTablesMock.Data;

namespace SchoolPerformanceTablesMock.Models;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new SchoolPerformanceTablesMockContext(
            serviceProvider.GetRequiredService<DbContextOptions<SchoolPerformanceTablesMockContext>>());
        if (context == null || context.School == null)
        {
            throw new ArgumentNullException("Null SchoolPerformanceTablesMockContext");
        }

        if (context.School.Any())
        {
            return;
        }
        
        context.School.AddRange(
            new School
            {
                Name = "Our Lady's Convent High School",
                SchoolType = "Voluntary aided school",
                MinAge = 11,
                MaxAge = 18,
                OfstedRating = "Good",
                Website = "www.olc.edu",
                EducationPhase = "Secondary",
                LocalAuthority = "Hackney"
            },
            
            new School
            {
                Name = "St Anne's RC Primary",
                SchoolType = "Maintained",
                MinAge = 4,
                MaxAge = 11,
                OfstedRating = "Outstanding",
                Website = "www.stannes.edu",
                EducationPhase = "Primary",
                LocalAuthority = "Tower Hamlets"
            },
            
            new School
            {
                Name = "Orchard",
                SchoolType = "Academy",
                MinAge = 4,
                MaxAge = 11,
                OfstedRating = "Poor",
                Website = "www.orchard.edu",
                EducationPhase = "Primary",
                LocalAuthority = "Hackney"
            }
            );
        context.SaveChanges();
    }
}
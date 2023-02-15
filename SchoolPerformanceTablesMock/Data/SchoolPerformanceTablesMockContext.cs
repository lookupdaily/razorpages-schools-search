using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolPerformanceTablesMock.Models;

namespace SchoolPerformanceTablesMock.Data
{
    public class SchoolPerformanceTablesMockContext : DbContext
    {
        public SchoolPerformanceTablesMockContext (DbContextOptions<SchoolPerformanceTablesMockContext> options)
            : base(options)
        {
        }

        public DbSet<SchoolPerformanceTablesMock.Models.School> School { get; set; } = default!;
    }
}

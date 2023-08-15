using Microsoft.EntityFrameworkCore;
using MinimalApi_Demo.Entities;

namespace MinimalApi_Demo.AppDbContext
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }
        public DbSet<EmployeeAttendancSheet> EmployeeAttendanc { get; set; }
    }
}

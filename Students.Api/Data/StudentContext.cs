using Microsoft.EntityFrameworkCore;
using Students.Model;

namespace Students.Data
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> StudentSet { get; set; }

        public StudentContext(DbContextOptions options) : base(options)
        {
        }
    }
}
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Students.Model;

namespace Students.Data
{
    public class StudentRepository : AsyncCrudRepository<Student>, IStudentRepository
    {
        private readonly StudentContext _context;
        
        public StudentRepository(StudentContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Student> FindByPeselAsync(long pesel)
        {
            return await _context.StudentSet.FirstOrDefaultAsync(x => x.Pesel == pesel);
        }
    }
}
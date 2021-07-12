using System.Collections.Generic;
using System.Threading.Tasks;
using Students.Model;

namespace Students.Services
{
    public interface IStudentService
    {
        Task<Student> AddAsync(Student student);
        Task<Student> FindAsync(long pesel);
        Task<Student> Update(long pesel, Student student);
        Task Delete(long pesel);
        Task<List<Student>> FindAll();
    }
}
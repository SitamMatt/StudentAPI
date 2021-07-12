using System.Threading.Tasks;
using Students.Model;

namespace Students.Data
{
    public interface IStudentRepository : ICrudRepository<Student>
    {
        Task<Student> FindByPeselAsync(long pesel);
    }
}
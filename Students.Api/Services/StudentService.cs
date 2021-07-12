using System.Collections.Generic;
using System.Threading.Tasks;
using Students.Data;
using Students.Model;

namespace Students.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> AddAsync(Student student)
        {
            var result = await _studentRepository.SaveAsync(student);
            await _studentRepository.CommitAsync();
            return result;
        }

        public async Task<List<Student>> FindAll()
        {
            return await _studentRepository.FindAllAsync();
        }

        public async Task<Student> FindAsync(long pesel)
        {
            return await _studentRepository.FindByPeselAsync(pesel);
        }

        public async Task<Student> Update(long pesel, Student student)
        {
            student.Pesel = pesel;
            var result = await _studentRepository.SaveAsync(student);
            await _studentRepository.CommitAsync();
            return result;
        }

        public async Task Delete(long pesel)
        {
            var entity = await _studentRepository.FindByPeselAsync(pesel);
            _studentRepository.Delete(entity);
            await _studentRepository.CommitAsync();
        }
    }
}
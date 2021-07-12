using System.Collections.Generic;
using Mapster;
using Students.Dto;
using Students.Model;

namespace Students.Mappers
{
    [Mapper]
    public interface IStudentMapper
    {
        public StudentDto ToDto(Student src);
        public Student ToDomain(StudentDto src);

        public List<StudentDto> ToDto(List<Student> src);
    }
}
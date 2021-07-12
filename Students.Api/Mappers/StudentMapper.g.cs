using System.Collections.Generic;
using Students.Dto;
using Students.Mappers;
using Students.Model;

namespace Students.Mappers
{
    public partial class StudentMapper : IStudentMapper
    {
        public StudentDto ToDto(Student p1)
        {
            return p1 == null ? null : new StudentDto()
            {
                Pesel = p1.Pesel,
                Firstname = p1.Firstname,
                Lastname = p1.Lastname
            };
        }
        public Student ToDomain(StudentDto p2)
        {
            return p2 == null ? null : new Student()
            {
                Pesel = p2.Pesel,
                Firstname = p2.Firstname,
                Lastname = p2.Lastname
            };
        }
        public List<StudentDto> ToDto(List<Student> p3)
        {
            if (p3 == null)
            {
                return null;
            }
            List<StudentDto> result = new List<StudentDto>(p3.Count);
            
            int i = 0;
            int len = p3.Count;
            
            while (i < len)
            {
                Student item = p3[i];
                result.Add(item == null ? null : new StudentDto()
                {
                    Pesel = item.Pesel,
                    Firstname = item.Firstname,
                    Lastname = item.Lastname
                });
                i++;
            }
            return result;
            
        }
    }
}
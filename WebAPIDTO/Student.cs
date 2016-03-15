using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDTO
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class StudentDTO
    {
        public Student ConvertToStudent(StudentViewModel student)
        {
            Student std = new Student();
            std.Id = student.Id;
            std.Name = student.Name;
            std.Address = student.Address;
            return std;
        }

        public StudentViewModel ConvertToStudentViewModel(Student student)
        {
            StudentViewModel std = new StudentViewModel();
            std.Id = student.Id;
            std.Name = student.Name;
            std.Address = student.Address;
            return std;
        }
    }
}

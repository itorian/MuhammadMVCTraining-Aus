using System.Collections.Generic;
using WebAPIModel;

namespace DTO
{
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

        public List<Student> ConvertToStudent(List<StudentViewModel> students)
        {
            List<Student> std = new List<Student>();
            foreach(var student in students)
            {
                std.Add(new Student { Id = student.Id, Name = student.Name, Address = student.Address });
            }
            return std;
        }

        public List<StudentViewModel> ConvertToStudentViewModel(List<Student> students)
        {
            List<StudentViewModel> std = new List<StudentViewModel>();
            foreach (var student in students)
            {
                std.Add(new StudentViewModel { Id = student.Id, Name = student.Name, Address = student.Address });
            }
            return std;
        }
    }
}

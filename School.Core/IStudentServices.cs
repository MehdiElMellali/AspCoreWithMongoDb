using School.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core
{
    public interface IStudentServices
    {
        List<Student> GetStudents();
        Student GetStudent(string id);
        void AddStudent(Student student);
        void DeleteStudent(string id);
        Student UpdateStudent(Student student);
    }
}

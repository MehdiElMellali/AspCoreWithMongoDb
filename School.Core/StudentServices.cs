using System;
using System.Collections.Generic;
using MongoDB.Driver;
using School.Core.Models;

namespace School.Core
{
    public class StudentServices : IStudentServices
    {
        private readonly IMongoCollection<Student> _students;

        public StudentServices(IDbClient db)
        {
            _students = db.GetStudentCollection();
        }

        public void AddStudent(Student student)
        {
            _students.InsertOne(student);
        }

        public void DeleteStudent(string id) => _students.DeleteOne(s => s.Id == id);

        public Student GetStudent(string id) => _students.Find(s => s.Id == id).FirstOrDefault();

        public List<Student> GetStudents()
        {
            return _students.Find(s => true).ToList();
        }

        public Student UpdateStudent(Student student)
        {
            GetStudent(student.Id);
            _students.ReplaceOne(s => s.Id == student.Id, student);
            return student;
        }
    }
}

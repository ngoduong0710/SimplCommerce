using System;
using System.Collections.Generic;
using System.Linq;
using FIT.Module.Students.Models;
using SimplCommerce.Infrastructure.Data;

namespace FIT.Module.Students.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void Create(string studentId, string studentName, bool isMale, int age)
        {
            Student student = new()
            {
                StudentID = studentId,
                FullName = studentName,
                isMale = isMale,
                Age = age
            };

            var checkExist = _studentRepository.Query().FirstOrDefault(student => student.StudentID == studentId);
            if (checkExist != null)
            {
                _studentRepository.Add(student);
            }
            else
            {
                throw new Exception("This student has been exits");
            }

        }

        public void Delete(long id)
        {
            var current = _studentRepository.Query()
                .FirstOrDefault(student => student.Id == id);
            if (current == null)
                throw new Exception("Student not found!");
            _studentRepository.Remove(current);
            _studentRepository.SaveChanges();
        }

        public Student Get(long Id)
        {
            var current = _studentRepository.Query()
                .FirstOrDefault(student => student.Id == Id);
            if (current == null)
                throw new Exception("Student not found!");
            else return current;
        }

        public IEnumerable<Student> GetAll()
        {
            var students = _studentRepository.Query().ToList();
            return students != null? students : throw new Exception("There are no students");
        }

        public void Update(long id, string studentId, string studentName, bool isMale, int age)
        {
            var current = _studentRepository.Query()
                .FirstOrDefault(student => student.Id == id);
            if (current == null)
                throw new Exception("Student not found!");
            current.StudentID = studentId;
            current.FullName = studentName;
            current.isMale = isMale;
            current.Age = age;

            _studentRepository.Update(current);
            _studentRepository.SaveChanges();
        }
    }
}

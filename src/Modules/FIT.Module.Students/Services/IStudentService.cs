using System.Collections.Generic;
using FIT.Module.Students.Models;

namespace FIT.Module.Students.Services
{
    public interface IStudentService
    {
        public void Create(string studentId, string studentName, bool isMale, int age);
        public void Update(long id, string studentId, string studentName, bool isMale, int age);
        public Student Get(long Id);
        public IEnumerable<Student> GetAll();
        public void Delete(long Id);
    }
}

using System.Collections.Generic;
using FIT.Module.Students.Models;
using FIT.Module.Students.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FIT.Module.Students.Areas.Students.Controllers
{
    [Area("Student")]
    [Authorize]
    [Route("api/student")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentApiController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public Student Get(long id)
        {
            return _studentService.Get(id);
        }

        [HttpGet("get-all")]
        public IEnumerable<Student> GetAll()
        {
            return _studentService.GetAll();
        }

        [HttpPost]
        public void Create(string studentId, string studentName, bool isMale, int age)
        {
            _studentService.Create(studentId, studentName, isMale, age);
        }

        [HttpPut]
        public void Update(long id, string studentId, string studentName, bool isMale, int age)
        {
            _studentService.Update(id, studentId, studentName, isMale, age);
        }

        [HttpDelete]
        public void Delete(long id)
        {
            _studentService.Delete(id);
        }
    }
}

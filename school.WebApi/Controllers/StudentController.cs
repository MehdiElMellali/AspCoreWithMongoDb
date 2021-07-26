using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School.Core;
using School.Core.Models;

namespace school.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {

        public IStudentServices _studentServices { get; set; }

        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(_studentServices.GetStudents());
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public IActionResult GetStudent(string id)
        {
            return Ok(_studentServices.GetStudent(id));
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            _studentServices.AddStudent(student);
            return CreatedAtRoute("GetStudent", new { id = student.Id }, student);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(string id)
        {
            _studentServices.DeleteStudent(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateStudent(Student student)
        {
            return Ok(_studentServices.UpdateStudent(student));
        }
    }
}

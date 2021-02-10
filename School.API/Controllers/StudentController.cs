using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Domain.Models;
using School.Repository.Data;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly Context _context;

        public StudentController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
             return Ok(_context.Students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _context.Students.FirstOrDefault(a => a.StudentID == id);
            if (student == null) return BadRequest("Aluno não encontrado.");

            return Ok(student);
        }


        [HttpGet("ByName")]
        public IActionResult GetByName(string name, string lastName)
        {
            var student = _context.Teachers.FirstOrDefault(a => a.Name.Contains(name) && a.Name.Contains(lastName));
            if (student == null) return BadRequest("Aluno não encontrado.");

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Post(Student Student)
        {
            _context.Add(Student);
            _context.SaveChanges();
            return Ok(Student);
        }

        [HttpPut]
        public IActionResult Put(int id, Student Student)
        {
            var student = _context.Students.AsNoTracking().FirstOrDefault(t => t.StudentID == id);
            if (student == null) return BadRequest("Aluno não encontrado.");

            _context.Update(Student);
            _context.SaveChanges();
            return Ok(Student);
        }

        [HttpDelete("{id}")]
        public IActionResult Patch(int id)
        {
            var student = _context.Students.AsNoTracking().FirstOrDefault(t => t.StudentID == id);
            if (student == null) return BadRequest("Aluno não encontrado.");

            _context.Remove(student);
            _context.SaveChanges();
            return Ok();
        }
    }
}

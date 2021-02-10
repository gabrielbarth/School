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
    public class TeacherController : ControllerBase
    {
        private readonly Context _context;

        public TeacherController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
             return Ok(_context.Teachers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(a => a.TeacherID == id);
            if (teacher == null) return BadRequest("Professor não encontrado.");

            return Ok(teacher);
        }


        [HttpGet("ByName")]
        public IActionResult GetByName(string name)
        {
            var teacher = _context.Teachers.FirstOrDefault(a => a.Name.Contains(name));
            if (teacher == null) return BadRequest("Professor não encontrado.");


            return Ok(teacher);
        }

        [HttpPost]
        public IActionResult Post(Teacher Teacher)
        {
            _context.Add(Teacher);
            _context.SaveChanges();
            return Ok(Teacher);
        }

        [HttpPut]
        public IActionResult Put(int id, Teacher Teacher)
        {
            var teacher = _context.Teachers.AsNoTracking().FirstOrDefault(t => t.TeacherID == id);
            if (teacher == null) return BadRequest("Professor não encontrado.");

            _context.Update(Teacher);
            _context.SaveChanges();
            return Ok(Teacher);
        }

        [HttpDelete("{id}")]
        public IActionResult Patch(int id)
        {
            var teacher = _context.Teachers.AsNoTracking().FirstOrDefault(t => t.TeacherID == id);
            if (teacher == null) return BadRequest("Professor não encontrado.");

            _context.Remove(teacher);
            _context.SaveChanges();
            return Ok();
        }
    }
}

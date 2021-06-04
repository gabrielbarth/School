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
        private readonly IRepository _repository;


        public StudentController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repository.GetAllStudents(true);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _repository.GetStudentById(id, false);
            if (student == null) return BadRequest("Aluno não encontrado.");

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Post(Student student)
        {
            _repository.Create(student);
            if (_repository.SaveChanges())
                return Ok(student);

            return BadRequest("Aluno não cadastrado.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Student Student)
        {
            var student = _repository.GetStudentById(id);
            if (student == null) return BadRequest("Aluno não encontrado.");

            _repository.Update(student);
            if (_repository.SaveChanges())
                return Ok(student);

            return BadRequest("Aluno não atualizado.");
        }

        [HttpDelete("{id}")]
        public IActionResult Patch(int id)
        {
            var student = _repository.GetStudentById(id);
            if (student == null) return BadRequest("Aluno não encontrado.");

            _repository.Delete(student);
            if (_repository.SaveChanges())
                return Ok("Aluno deletado.");

            return BadRequest("Aluno não deletado.");
        }
    }
}

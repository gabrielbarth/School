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
        private readonly IRepository _repository;

        public TeacherController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repository.GetAllTeachers(true);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var teacher = _repository.GetTeacherById(id, false);
            if (teacher == null) return BadRequest("Professor não encontrado.");

            return Ok(teacher);
        }


        [HttpPost]
        public IActionResult Post(Teacher teacher)
        {
            _repository.Create(teacher);
            if (_repository.SaveChanges())
                return Ok(teacher);

            return BadRequest("Professor não cadastrado.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Teacher Teacher)
        {
            var teacher = _repository.GetTeacherById(id);
            if (teacher == null) return BadRequest("Professor não encontrado.");

            _repository.Update(teacher);
            if (_repository.SaveChanges())
                return Ok(teacher);

            return BadRequest("Aluno não atualizado.");
        }

        [HttpDelete("{id}")]
        public IActionResult Patch(int id)
        {
            var teacher = _repository.GetTeacherById(id);
            if (teacher == null) return BadRequest("Professor não encontrado.");

            _repository.Delete(teacher);
            if (_repository.SaveChanges())
                return Ok("Professor deletado.");

            return BadRequest("Aluno não atualizado.");
        }
    }
}

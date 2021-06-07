using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Domain.Models;
using School.Infra.DTOs;
using School.Repository.Data;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public StudentController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var students = _repository.GetAllStudents(true).ToList();
            return Ok(_mapper.Map<IEnumerable<StudentDto>>(students));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _repository.GetStudentById(id, false);
            if (student == null) return BadRequest("Aluno não encontrado.");

            var studentDto = _mapper.Map<StudentDto>(student);

            return Ok(studentDto);
        }

        [HttpPost]
        public IActionResult Post(StudentRegisterDto studentModel)
        {
            var student = _mapper.Map<Student>(studentModel);

            _repository.Create(student);
            if (_repository.SaveChanges())
                return Created($"/api/student/{studentModel.StudentID}", _mapper.Map<StudentDto>(student));

            return BadRequest("Aluno não cadastrado.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, StudentRegisterDto studentModel)
        {
            var student = _repository.GetStudentById(id);
            if (student == null) return BadRequest("Aluno não encontrado.");

            _mapper.Map(studentModel, student);

            _repository.Update(student);
            if (_repository.SaveChanges())
                return Created($"/api/student/{studentModel.StudentID}", _mapper.Map<StudentDto>(student));

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

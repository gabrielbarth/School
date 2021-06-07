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
    public class TeacherController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public TeacherController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var teachers = _repository.GetAllTeachers(true);
            return Ok(_mapper.Map<IEnumerable<TeacherDto>>(teachers));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var teacher = _repository.GetTeacherById(id, false);
            if (teacher == null) return BadRequest("Professor não encontrado.");

            var teacherDto = _mapper.Map<TeacherDto>(teacher);

            return Ok(teacherDto);
        }


        [HttpPost]
        public IActionResult Post(TeacherRegisterDto teacherModel)
        {
            var teacher = _mapper.Map<Teacher>(teacherModel);

            _repository.Create(teacher);
            if (_repository.SaveChanges())
                return Created($"/api/teacher/{teacherModel.TeacherID}", _mapper.Map<TeacherDto>(teacher));

            return BadRequest("Professor não cadastrado.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TeacherRegisterDto teacherModel)
        {
            var teacher = _repository.GetTeacherById(id);
            if (teacher == null) return BadRequest("Professor não encontrado.");

            _mapper.Map(teacherModel, teacher);

            _repository.Update(teacher);
            if (_repository.SaveChanges())
                return Created($"/api/teacher/{teacherModel.TeacherID}", _mapper.Map<TeacherDto>(teacher));

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

using AutoMapper;
using School.Domain.Models;
using School.Infra.DTOs;

namespace School.Application.Helpers
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name} {src.LastName}")
                )
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.BornDate.GetCurrentAge())
               );

            CreateMap<StudentDto, Student>();
            CreateMap<Student, StudentRegisterDto>().ReverseMap();

            CreateMap<Teacher, TeacherDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name} {src.LastName}")
                );

            CreateMap<TeacherDto, Teacher>();
            CreateMap<Teacher, TeacherRegisterDto>().ReverseMap();
        }
    }
}

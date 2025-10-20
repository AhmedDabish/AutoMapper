using AutoMapper;
using AutoMapperExample.DTOs;
using AutoMapperExample.Models;

namespace AutoMapperExample.Profiles
{
    public class StudentProfile:Profile
    {
        public StudentProfile()
        {
            CreateMap<CreateStudentDto, Student>();
            CreateMap<Student, StudentDto>();
        }
    }
    
}

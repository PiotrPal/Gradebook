using AutoMapper;
using Gradebook.App.Dtos;
using Gradebook.Domain.Entities;

namespace Gradebook.App.Configuration.Mappings {
    public class StudentMappingProfile : Profile{
        public StudentMappingProfile()
        {
            CreateMap<Student,StudentDto>()
                .ForMember(dest => dest.Age, conf => conf.MapFrom(
                    model => DateTime.Now.Year - model.DateOfBirth.ToDateTime(TimeOnly.Parse("00:00")).Year));
        }
    }
}

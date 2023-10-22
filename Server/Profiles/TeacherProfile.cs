using ElectronicJournal.Shared.DTOs.TeacherDto;
using ElectronicJournal.Shared.Entity;

namespace ElectronicJournal.Server.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<CreateTeacherDto, Teacher>();
            CreateMap<UpdateTeacherDto, Teacher>();
            CreateMap<Teacher, GetTeacherDto>();
        }
    }
}

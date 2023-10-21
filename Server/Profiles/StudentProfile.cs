using ElectronicJournal.Shared.DTOs.StudentDto;
using ElectronicJournal.Shared.Entity;

namespace ElectronicJournal.Server.Profiles
{
	public class StudentProfile : Profile
	{
		public StudentProfile()
		{
			CreateMap<CreateStudentDto, Student>();
			CreateMap<UpdateStudentDto, Student>();
			CreateMap<Student, StudentDto>()
				.ForMember(
				dest => dest.SchoolClassFullName,
				opt => opt.MapFrom(
					src => $"{src.SchoolClass.Course}{src.SchoolClass.Name}"
					)
				);
		}
	}
}

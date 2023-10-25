using ElectronicJournal.Shared.DTOs.JournalDto;
using ElectronicJournal.Shared.Entity;

namespace ElectronicJournal.Server.Profiles
{
	public class JournalProfile : Profile
	{
		public JournalProfile()
		{
			CreateMap<CreateJournalDto, Journal>();
			CreateMap<Journal, GetJournalDto>()
				.ForMember(dest => dest.SchoolClassName, opt => opt
				.MapFrom(src => $"{src.SchoolClass.Course}{src.SchoolClass.Name}")
				);

			CreateMap<Journal, GetJournalDetailsDto>()
				.ForMember(dest => dest.SchoolClassName, opt => opt
				.MapFrom(src => $"{src.SchoolClass.Course}{src.SchoolClass.Name}")
				)
				.ForMember(dest => dest.Schedules, opt => opt.MapFrom(src => src.Schedules)
				);

			CreateMap<Schedule, GetScheduleDto>()
				.ForMember(dest => dest.Subject, opt => opt
				.MapFrom(src => src.Subject.Name)
				)
				.ForMember(dest => dest.Teacher, opt => opt
				.MapFrom(src => src.Teacher.FullName)
				);
		}
	}
}

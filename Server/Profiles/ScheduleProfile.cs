using ElectronicJournal.Shared.DTOs.ScheduleDto;
using ElectronicJournal.Shared.Entity;

namespace ElectronicJournal.Server.Profiles
{
	public class ScheduleProfile : Profile
	{
		public ScheduleProfile()
		{
			CreateMap<CreateScheduleDto, Schedule>();
			CreateMap<UpdateScheduleDto, Schedule>();
			CreateMap<Schedule, GetScheduleDto>()
				.ForMember(dest => dest.Teacher, opt => opt
				.MapFrom(src => src.Teacher.FullName))
				.ForMember(dest => dest.Subject, opt => opt
				.MapFrom(src => src.Subject.Name)
				);
		}

	}
}

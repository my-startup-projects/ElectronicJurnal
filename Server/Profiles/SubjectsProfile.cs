using ElectronicJournal.Shared.DTOs.SubjectDto;
using ElectronicJournal.Shared.Entity;

namespace ElectronicJournal.Server.Profiles
{
	public class SubjectsProfile : Profile
	{
		public SubjectsProfile()
		{
			CreateMap<CreateSubjectDto, Subject>();
			CreateMap<UpdateSubjectDto, Subject>();
			CreateMap<Subject, GetSubjectDto>();
		}

	}
}

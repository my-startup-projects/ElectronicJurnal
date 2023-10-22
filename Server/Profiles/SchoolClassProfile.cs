using ElectronicJournal.Shared.DTOs.SchoolClassDto;
using ElectronicJournal.Shared.Entity;

namespace ElectronicJournal.Server.Profiles
{
	public class SchoolClassProfile : Profile
	{
        public SchoolClassProfile()
        {
            CreateMap<CreateSchoolClassDto, SchoolClass>();
            CreateMap<UpdateSchoolClassDto,SchoolClass > ();
            CreateMap<SchoolClass, GetSchoolClassDto> ();
        }
    }
}

using ElectronicJournal.Shared.DTOs.SchoolClassDto;
using ElectronicJournal.Shared.Entity;
using ElectronicJournal.Shared.Response;

namespace ElectronicJournal.Server.Services.SchoolClasses
{
	public interface ISchoolClassesService
	{
		Task<ServiceResponse<List<GetSchoolClassDto>>> GetAll();
		Task<ServiceResponse<Guid>> CreateSchoolClass(CreateSchoolClassDto schoolClass);
		Task<ServiceResponse<GetSchoolClassDto>> UpdateSchoolClass(UpdateSchoolClassDto schoolClass);
		Task<ServiceResponse<bool>> DeleteSchoolClass(Guid schoolClassId);
	}
}

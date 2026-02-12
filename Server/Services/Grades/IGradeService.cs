using ElectronicJournal.Shared.DTOs.GradeDto;
using ElectronicJournal.Shared.Response;

namespace ElectronicJournal.Server.Services.Grades
{
    public interface IGradeService
    {
        Task<ServiceResponse<Guid>> Create(CreateGradeDto createGradeDto);
        Task<ServiceResponse<GetGradeDto>> Get(Guid scheduleId, DateTime date);
        Task<ServiceResponse<GetGradeDto>> Get(Guid gradeId);
	}
}

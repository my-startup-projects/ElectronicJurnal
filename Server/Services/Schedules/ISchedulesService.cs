using ElectronicJournal.Shared.DTOs.ScheduleDto;
using ElectronicJournal.Shared.Identity;
using ElectronicJournal.Shared.Response;

namespace ElectronicJournal.Server.Services.Schedules
{
	public interface ISchedulesService
	{
		Task<ServiceResponse<Guid>> CreateSchedules(CreateScheduleDto scheduleDto);
		Task<ServiceResponse<GetScheduleDto>> UpdateSchedules(UpdateScheduleDto scheduleDto);
		Task<ServiceResponse<bool>> DeleteSchedules(Guid scheduleId);
		Task<ServiceResponse<List<GetScheduleDto>>> GetAllSchedules();
	}
}

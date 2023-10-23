using ElectronicJournal.Server.DataBase;
using ElectronicJournal.Shared.DTOs.ScheduleDto;
using ElectronicJournal.Shared.Entity;
using ElectronicJournal.Shared.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace ElectronicJournal.Server.Services.Schedules
{
	public class SchedulesService : ISchedulesService
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly IMapper _mapper;

		public SchedulesService(ApplicationDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}
		public async Task<ServiceResponse<Guid>> CreateSchedules(CreateScheduleDto scheduleDto)
		{
			try
			{
				var schedule = _mapper.Map<Schedule>(scheduleDto);
				await _dbContext.Schedules.AddAsync(schedule);
				await _dbContext.SaveChangesAsync();
				return new ServiceResponse<Guid>() { Data = schedule.Id };
			}
			catch (Exception ex)
			{
				return new ServiceResponse<Guid>() { Success = false, Message = ex.Message };
			}
		}

		public async Task<ServiceResponse<bool>> DeleteSchedules(Guid scheduleId)
		{
			try
			{
				var schedule = await _dbContext.Schedules
					.FirstOrDefaultAsync(s => s.Id == scheduleId);
				if (schedule == null)
					return new ServiceResponse<bool>() { Success = false, Message = "schedule not found" };

				_dbContext.Schedules.Remove(schedule);
				await _dbContext.SaveChangesAsync();
				return new ServiceResponse<bool>() { Data = true };
			}
			catch (Exception ex)
			{
				return new ServiceResponse<bool>() { Success = false, Message = ex.Message };
			}
		}

		public async Task<ServiceResponse<List<GetScheduleDto>>> GetAllSchedules()
		{
			try
			{
				var schedules = await _dbContext.Schedules
					.Include(s => s.Journal)
					.Include(s => s.Teacher)
					.Include(s => s.Subject)
					.ToListAsync();

				return new ServiceResponse<List<GetScheduleDto>>()
				{
					Data = schedules.Select(s => _mapper.Map<GetScheduleDto>(s)).ToList()
				};
			}
			catch (Exception ex)
			{
				return new ServiceResponse<List<GetScheduleDto>>() { Success = false, Message = ex.Message };
			}
		}

		public async Task<ServiceResponse<GetScheduleDto>> UpdateSchedules(UpdateScheduleDto scheduleDto)
		{
			try
			{
				var schedule = await _dbContext.Schedules
					.FirstOrDefaultAsync(s => s.Id == scheduleDto.Id);
				if (schedule == null)
					return new ServiceResponse<GetScheduleDto>() { Success = false, Message = "schedule not found" };

				schedule = _mapper.Map<Schedule>(scheduleDto);
				await _dbContext.SaveChangesAsync();

				return new ServiceResponse<GetScheduleDto>() { Data = _mapper.Map<GetScheduleDto>(schedule) };

			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}

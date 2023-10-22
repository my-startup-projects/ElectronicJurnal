using ElectronicJournal.Server.Services.Schedules;
using ElectronicJournal.Shared.DTOs.ScheduleDto;
using Microsoft.AspNetCore.Mvc;
using ZstdSharp.Unsafe;

namespace ElectronicJournal.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SchedulesController : ControllerBase
	{
		private readonly ISchedulesService _schedulesService;

		public SchedulesController(ISchedulesService schedulesService)
		{
			_schedulesService = schedulesService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var response = await _schedulesService.GetAllSchedules();
			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateScheduleDto schedule)
		{
			var response = await _schedulesService.CreateSchedules(schedule);
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] UpdateScheduleDto schedule)
		{
			var response = await _schedulesService.UpdateSchedules(schedule);
			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var response = await _schedulesService.DeleteSchedules(id);
			return Ok(response);
		}
	}
}

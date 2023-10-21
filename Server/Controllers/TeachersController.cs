using ElectronicJournal.Server.Services.Teachers;
using ElectronicJournal.Shared.DTOs.TeacherDto;
using ElectronicJournal.Shared.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicJournal.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeachersController : ControllerBase
	{
		private readonly ITeachersService _teachersService;

		public TeachersController(ITeachersService teachersService)
		{
			_teachersService = teachersService;
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] CreateTeacherDto teacherDto)
		{
			var response = await _teachersService.AddTeacher(teacherDto);
			if (!response.Success)
				return BadRequest(response.Message);
			return Ok(response);
		}

		[HttpDelete("{teacherId}")]
		public async Task<IActionResult> Delete([FromRoute] Guid teacherId)
		{
			var response = await _teachersService.RemoveTeacher(teacherId);
			if (!response.Success)
				return BadRequest(response.Message);
			return Ok(response);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var response = await _teachersService.GetTeachers();
			if (!response.Success)
				return BadRequest(response.Message);
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateTeacher([FromBody] UpdateTeacherDto updateTeacherDto)
		{
			var response = await _teachersService.UpdateTeacher(updateTeacherDto);
			if (!response.Success)
				return BadRequest(response.Message);
			return Ok(response);
		}
	}
}

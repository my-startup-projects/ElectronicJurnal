using ElectronicJournal.Server.Services.Students;
using ElectronicJournal.Shared.DTOs.StudentDto;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicJournal.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		private readonly IStudentsService _StudentsService;

		public StudentsController(IStudentsService StudentsService)
		{
			_StudentsService = StudentsService;
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] CreateStudentDto StudentDto)
		{
			var response = await _StudentsService.AddStudent(StudentDto);
			if (!response.Success)
				return BadRequest(response.Message);
			return Ok(response);
		}

		[HttpDelete("{StudentId}")]
		public async Task<IActionResult> Delete([FromRoute] Guid StudentId)
		{
			var response = await _StudentsService.RemoveStudent(StudentId);
			if (!response.Success)
				return BadRequest(response.Message);
			return Ok(response);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var response = await _StudentsService.GetStudents();
			if (!response.Success)
				return BadRequest(response.Message);
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentDto updateStudentDto)
		{
			var response = await _StudentsService.UpdateStudent(updateStudentDto);
			if (!response.Success)
				return BadRequest(response.Message);
			return Ok(response);
		}
	}
}

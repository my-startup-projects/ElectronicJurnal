using ElectronicJournal.Server.Services.Students;
using ElectronicJournal.Shared.DTOs.StudentDto;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg.Sig;

namespace ElectronicJournal.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		private readonly IStudentsService _studentsService;

		public StudentsController(IStudentsService StudentsService)
		{
			_studentsService = StudentsService;
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] CreateStudentDto StudentDto)
		{
			var response = await _studentsService.AddStudent(StudentDto);
			if (!response.Success)
				return BadRequest(response.Message);
			return Ok(response);
		}

		[HttpDelete("{StudentId}")]
		public async Task<IActionResult> Delete([FromRoute] Guid StudentId)
		{
			var response = await _studentsService.RemoveStudent(StudentId);
			if (!response.Success)
				return BadRequest(response.Message);
			return Ok(response);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var response = await _studentsService.GetStudents();
			if (!response.Success)
				return BadRequest(response.Message);
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentDto updateStudentDto)
		{
			var response = await _studentsService.UpdateStudent(updateStudentDto);
			if (!response.Success)
				return BadRequest(response.Message);
			return Ok(response);
		}

		[HttpPost("AddStudentToSchoolClass")]
		public async Task<IActionResult> AddStudentToSchoolClass([FromQuery] Guid studentId, [FromQuery] Guid schoolClassId)
		{
			var response= await _studentsService.AddStudentToSchoolClass(studentId, schoolClassId);
			return Ok(response);
		}
	}
}

using ElectronicJournal.Server.Services.Subjects;
using ElectronicJournal.Shared.DTOs.SubjectDto;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicJournal.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SubjectController : ControllerBase
	{
		private readonly ISubjectsService _subjectsService;

		public SubjectController(ISubjectsService subjectsService)
		{
			_subjectsService = subjectsService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{

			var response = await _subjectsService.GetSubjects();
			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateSubjectDto createSubjectDto)
		{
			var response = await _subjectsService.CreateSubject(createSubjectDto);
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] UpdateSubjectDto updateSubjectDto)
		{
			var response = await _subjectsService.UpdateSubject(updateSubjectDto);
			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			var response = await _subjectsService.DeleteSubject(id);
			return Ok(response);
		}
	}
}

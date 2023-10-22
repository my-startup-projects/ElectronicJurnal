using ElectronicJournal.Server.Services.SchoolClasses;
using ElectronicJournal.Shared.DTOs.SchoolClassDto;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicJournal.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SchoolClassController : ControllerBase
	{
		private readonly ISchoolClassesService _schoolClassesService;

		public SchoolClassController(ISchoolClassesService schoolClassesService)
		{
			_schoolClassesService = schoolClassesService;
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateSchoolClassDto schoolClass)
		{
			var response = await _schoolClassesService.CreateSchoolClass(schoolClass);
			return Ok(response);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var response = await _schoolClassesService.GetAll();
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] UpdateSchoolClassDto schoolClass)
		{
			var responce = await _schoolClassesService.UpdateSchoolClass(schoolClass);
			return Ok(responce);
		}

		[HttpDelete("{Id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid Id)
		{
			var response = await _schoolClassesService.DeleteSchoolClass(Id);
			return Ok(response);
		}
	}
}

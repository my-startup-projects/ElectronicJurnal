using ElectronicJournal.Server.Services.Journals;
using ElectronicJournal.Shared.DTOs.JournalDto;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicJournal.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JournalController : ControllerBase
	{
		private readonly IJournalsService _journalsService;

		public JournalController(IJournalsService journalsService)
		{
			_journalsService = journalsService;
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateJournalDto createJournalDto)
		{
			var response= await _journalsService.CreateJournal(createJournalDto);
			return Ok(response);
		}
	}
}

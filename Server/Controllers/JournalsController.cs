using ElectronicJournal.Server.Services.Journals;
using ElectronicJournal.Shared.DTOs.JournalDto;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicJournal.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JournalsController : ControllerBase
	{
		private readonly IJournalsService _journalsService;

		public JournalsController(IJournalsService journalsService)
		{
			_journalsService = journalsService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var response = await _journalsService.GetAll();
			return Ok(response.Data);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateJournalDto createJournalDto)
		{
			var response = await _journalsService.CreateJournal(createJournalDto);
			return Ok(response);
		}

		[HttpGet("{journalId}")]
		public async Task<IActionResult> GetJournalById([FromRoute] Guid journalId)
		{
			var resppnse = await _journalsService.GetJournal(journalId);
			return Ok(resppnse);
		}
	}
}

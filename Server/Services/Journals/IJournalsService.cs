using ElectronicJournal.Shared.DTOs.JournalDto;
using ElectronicJournal.Shared.Response;

namespace ElectronicJournal.Server.Services.Journals
{
	public interface IJournalsService
	{
		Task<ServiceResponse<Guid>> CreateJournal(CreateJournalDto createJournalDto);
		Task<ServiceResponse<bool>> DeleteJournal(Guid jurnalId);
	}
}

using ElectronicJournal.Server.DataBase;
using ElectronicJournal.Shared.DTOs.JournalDto;
using ElectronicJournal.Shared.Entity;
using ElectronicJournal.Shared.Response;
using Microsoft.EntityFrameworkCore;

namespace ElectronicJournal.Server.Services.Journals
{
	public class JournalsService : IJournalsService
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly IMapper _mapper;

		public JournalsService(ApplicationDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<Guid>> CreateJournal(CreateJournalDto createJournalDto)
		{
			try
			{
				var schoolClass = await _dbContext.SchoolClasses
					.FirstOrDefaultAsync(sc => sc.Id == createJournalDto.SchoolClassId);
				if (schoolClass == null)
					return new ServiceResponse<Guid>() { Success = false, Message = "schoolClass not found" };

				var journal = _mapper.Map<Journal>(createJournalDto);
				await _dbContext.Journals.AddAsync(journal);
				await _dbContext.SaveChangesAsync();
				return new ServiceResponse<Guid>() { Data = journal.Id };
			}
			catch (Exception ex)
			{
				return new ServiceResponse<Guid>() { Success = false, Message = ex.Message };
			}
		}

		public async Task<ServiceResponse<bool>> DeleteJournal(Guid journalId)
		{
			try
			{
				var journal = await _dbContext.Journals.FirstOrDefaultAsync(j => j.Id == journalId);
				if (journal == null)
					return new ServiceResponse<bool>() { Success = false, Message = "jourmal nout found" };

				_dbContext.Journals.Remove(journal);
				await _dbContext.SaveChangesAsync();

				return new ServiceResponse<bool>() { Data = true };
			}
			catch (Exception ex)
			{
				return new ServiceResponse<bool>() { Success = false, Message = ex.Message };
			}
		}
	}
}

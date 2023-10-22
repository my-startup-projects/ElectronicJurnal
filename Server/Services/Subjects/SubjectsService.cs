using ElectronicJournal.Server.DataBase;
using ElectronicJournal.Shared.DTOs.SubjectDto;
using ElectronicJournal.Shared.Entity;
using ElectronicJournal.Shared.Response;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg;

namespace ElectronicJournal.Server.Services.Subjects
{
	public class SubjectsService : ISubjectsService
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly IMapper _mapper;

		public SubjectsService(ApplicationDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<Guid>> CreateSubject(CreateSubjectDto subjectDto)
		{
			try
			{
				var subject = _mapper.Map<Subject>(subjectDto);
				await _dbContext.Subjects.AddAsync(subject);
				await _dbContext.SaveChangesAsync();
				return new ServiceResponse<Guid>() { Data = subject.Id };
			}
			catch (Exception ex)
			{
				return new ServiceResponse<Guid>() { Success = false, Message = ex.Message };
			}
		}

		public async Task<ServiceResponse<bool>> DeleteSubject(Guid id)
		{
			try
			{
				var subject = await _dbContext.Subjects
					.FirstOrDefaultAsync(s => s.Id == id);
				if (subject == null)
					return new ServiceResponse<bool>() { Success = false, Message = "subject not found" };
				_dbContext.Subjects.Remove(subject);

				await _dbContext.SaveChangesAsync();
				return new ServiceResponse<bool>() { Data = true };
			}
			catch (Exception ex)
			{
				return new ServiceResponse<bool>() { Success = false, Message = ex.Message };
			}
		}

		public async Task<ServiceResponse<List<GetSubjectDto>>> GetSubjects()
		{
			try
			{
				var subjects = await _dbContext.Subjects
					.ToListAsync();
				return new ServiceResponse<List<GetSubjectDto>>()
				{
					Data = subjects.Select(subject => _mapper.Map<GetSubjectDto>(subject)).ToList()
				};
			}
			catch (Exception ex)
			{
				return new ServiceResponse<List<GetSubjectDto>>() { Success = false, Message = ex.Message };
			}
		}

		public async Task<ServiceResponse<GetSubjectDto>> UpdateSubject(UpdateSubjectDto subjectDto)
		{
			try
			{
				var subject = await _dbContext.Subjects
					.FirstOrDefaultAsync(s => s.Id == subjectDto.Id);
				if (subject == null)
					return new ServiceResponse<GetSubjectDto>() { Success = false, Message = "subject not found" };

				subject = _mapper.Map<Subject>(subjectDto);

				await _dbContext.SaveChangesAsync();

				return new ServiceResponse<GetSubjectDto>() { Data = _mapper.Map<GetSubjectDto>(subject) };

			}
			catch (Exception ex)
			{
				return new ServiceResponse<GetSubjectDto>() { Success = false, Message = ex.Message };
			}
		}
	}
}

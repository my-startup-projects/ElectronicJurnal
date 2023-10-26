using ElectronicJournal.Server.DataBase;
using ElectronicJournal.Shared.DTOs.GradeDto;
using ElectronicJournal.Shared.Entity;
using ElectronicJournal.Shared.Response;
using Microsoft.EntityFrameworkCore;

namespace ElectronicJournal.Server.Services.Grades
{
	public class GradeService : IGradeService
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly IMapper _mapper;

		public GradeService(ApplicationDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<Guid>> Create(CreateGradeDto createGradeDto)
		{
			try
			{
				var gradeCheck = await _dbContext.Grades
						.Where(g => g.ScheduleID == createGradeDto.ScheduleID && g.Date == createGradeDto.Date)
						.SingleOrDefaultAsync();
				if (gradeCheck != null)
				{
					return new ServiceResponse<Guid>
					{
						Success = false,
						Message = "Grade is exist!"
					};
				}
				var grade = _mapper.Map<Grade>(createGradeDto);
				_dbContext.Grades.Add(grade);
				await _dbContext.SaveChangesAsync();
				return new ServiceResponse<Guid> { Data = grade.Id };
			}
			catch (Exception ex)
			{
				return new ServiceResponse<Guid>
				{
					Message = ex.Message,
					Success = false
				};
			}
		}

		public Task<ServiceResponse<GetGradeDto>> Get(Guid gradeId)
		{
			throw new NotImplementedException();
		}

		public Task<ServiceResponse<GetGradeDto>> Get(Guid scheduleId, DateTime date)
		{
			try
			{

			}
			catch (Exception ex)
			{
				
			}
		}
	}
}

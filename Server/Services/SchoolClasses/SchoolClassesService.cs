using ElectronicJournal.Server.DataBase;
using ElectronicJournal.Shared.DTOs.SchoolClassDto;
using ElectronicJournal.Shared.Entity;
using ElectronicJournal.Shared.Response;
using Microsoft.EntityFrameworkCore;

namespace ElectronicJournal.Server.Services.SchoolClasses
{
	public class SchoolClassesService : ISchoolClassesService
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly IMapper _mapper;

		public SchoolClassesService(ApplicationDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<Guid>> CreateSchoolClass(CreateSchoolClassDto schoolClass)
		{
			try
			{
				var newSchoolClass = _mapper.Map<SchoolClass>(schoolClass);
				await _dbContext.SchoolClasses.AddAsync(newSchoolClass);
				await _dbContext.SaveChangesAsync();
				return new ServiceResponse<Guid>() { Data = newSchoolClass.Id };
			}
			catch (Exception ex)
			{
				return new ServiceResponse<Guid>() { Success = false, Message = ex.Message };
			}
		}

		public async Task<ServiceResponse<bool>> DeleteSchoolClass(Guid schoolClassId)
		{
			try
			{
				var schoolClass = await _dbContext.SchoolClasses
					.FirstOrDefaultAsync(sc => sc.Id == schoolClassId);
				if (schoolClass == null)
					return new ServiceResponse<bool>() { Message = "schoolClass not found", Success = false };

				_dbContext.SchoolClasses.Remove(schoolClass);
				await _dbContext.SaveChangesAsync();
				return new ServiceResponse<bool>() { Data = true };
			}
			catch (Exception ex)
			{
				return new ServiceResponse<bool> { Success = false, Message = ex.Message };
			}
		}

		public async Task<ServiceResponse<List<GetSchoolClassDto>>> GetAll()
		{
			try
			{
				var schoolClasses = await _dbContext.SchoolClasses
					.Include(sc => sc.Students)
					.Include(sc => sc.Journals)
					.ToListAsync();
				return new ServiceResponse<List<GetSchoolClassDto>>()
				{
					Data = schoolClasses.Select(sc => _mapper.Map<GetSchoolClassDto>(sc)).ToList()
				};
			}
			catch (Exception ex)
			{
				return new ServiceResponse<List<GetSchoolClassDto>>()
				{
					Success = false,
					Message = ex.Message
				};
			}
		}

		public async Task<ServiceResponse<GetSchoolClassDto>> UpdateSchoolClass(UpdateSchoolClassDto schoolClass)
		{
			try
			{
				var schoolClassFromDb = await _dbContext.SchoolClasses
					.FirstOrDefaultAsync(sc => sc.Id == schoolClass.Id);
				if (schoolClassFromDb == null)
					return new ServiceResponse<GetSchoolClassDto> { Success = false, Message = "schoolClass not found" };
				_mapper.Map(schoolClass, schoolClassFromDb);
				await _dbContext.SaveChangesAsync();
				return new ServiceResponse<GetSchoolClassDto>() { Data = _mapper.Map<GetSchoolClassDto>(schoolClassFromDb) };
			}
			catch (Exception ex)
			{
				return new ServiceResponse<GetSchoolClassDto>() { Success = false, Message = ex.Message };
			}
		}
	}
}

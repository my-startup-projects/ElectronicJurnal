using ElectronicJournal.Server.DataBase;
using ElectronicJournal.Shared.DTOs.TeacherDto;
using ElectronicJournal.Shared.Entity;
using ElectronicJournal.Shared.Identity;
using ElectronicJournal.Shared.Response;
using Microsoft.EntityFrameworkCore;

namespace ElectronicJournal.Server.Services.Teachers
{
	public class TeachersService : ITeachersService
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly IMapper _mapper;

		public TeachersService(ApplicationDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<bool>> AddTeacher(CreateTeacherDto teacherDto)
		{
			var response = new ServiceResponse<bool>();
			try
			{
				var teacher = _mapper.Map<Teacher>(teacherDto);
				teacher.Role = ApplicationRoles.Teacher;

				await _dbContext.AddAsync(teacher);
				await _dbContext.SaveChangesAsync();
				response.Data = true;
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message.ToString();
			}
			return response;
		}

		public async Task<ServiceResponse<List<Teacher>>> GetTeachers()
		{
			var response = new ServiceResponse<List<Teacher>>();
			try
			{
				var teachers = await _dbContext.Teachers.ToListAsync();
				response.Data = teachers;
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message.ToString();
			}
			return response;
		}

		public async Task<ServiceResponse<bool>> RemoveTeacher(Guid teacherId)
		{
			var response = new ServiceResponse<bool>();
			try
			{
				var teacher = await _dbContext.Teachers.FirstOrDefaultAsync(t => t.Id == teacherId);
				if (teacher == null)
				{
					response.Success = false;
					response.Message = "Teacher not found";
					return response;
				}

				_dbContext.Teachers.Remove(teacher);
				await _dbContext.SaveChangesAsync();
				response.Data = true;
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message.ToString();
			}
			return response;
		}

		public async Task<ServiceResponse<GetTeacherDto>> UpdateTeacher(UpdateTeacherDto updateTeacherDto)
		{
			var respoonse = new ServiceResponse<GetTeacherDto>();
			try
			{
				var teacher = await _dbContext.Teachers
					.FirstOrDefaultAsync(t => t.Id == updateTeacherDto.Id);
				if (teacher == null)
				{
					respoonse.Success = false;
					respoonse.Message = "Teacher not found";
					return respoonse;
				}

				_mapper.Map(updateTeacherDto, teacher);
				await _dbContext.SaveChangesAsync();

				respoonse.Data = _mapper.Map<GetTeacherDto>(teacher);
			}
			catch (Exception ex)
			{
				respoonse.Success = false;
				respoonse.Message = ex.Message.ToString();
			}
			return respoonse;
		}
	}
}

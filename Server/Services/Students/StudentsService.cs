using ElectronicJournal.Server.DataBase;
using ElectronicJournal.Shared.DTOs.StudentDto;
using ElectronicJournal.Shared.Entity;
using ElectronicJournal.Shared.Identity;
using ElectronicJournal.Shared.Response;
using Microsoft.EntityFrameworkCore;

namespace ElectronicJournal.Server.Services.Students
{
	public class StudentsService : IStudentsService
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly IMapper _mapper;

		public StudentsService(ApplicationDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<bool>> AddStudent(CreateStudentDto studentsDto)
		{
			var response = new ServiceResponse<bool>();
			try
			{
				var Student = _mapper.Map<Student>(studentsDto);
				Student.Role = ApplicationRoles.Student;

				await _dbContext.AddAsync(Student);
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

		public async Task<ServiceResponse<List<Student>>> GetStudents()
		{
			var response = new ServiceResponse<List<Student>>();
			try
			{
				var Students = await _dbContext.Students.ToListAsync();
				response.Data = Students;
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message.ToString();
			}
			return response;
		}

		public async Task<ServiceResponse<bool>> RemoveStudent(Guid studentId)
		{
			var response = new ServiceResponse<bool>();
			try
			{
				var Student = await _dbContext.Students.FirstOrDefaultAsync(t => t.Id == studentId);
				if (Student == null)
				{
					response.Success = false;
					response.Message = "Student not found";
					return response;
				}

				_dbContext.Students.Remove(Student);
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

		public async Task<ServiceResponse<StudentDto>> UpdateStudent(UpdateStudentDto updateStudentDto)
		{
			var respoonse = new ServiceResponse<StudentDto>();
			try
			{
				var Student = await _dbContext.Students
					.FirstOrDefaultAsync(t => t.Id == updateStudentDto.Id);
				if (Student == null)
				{
					respoonse.Success = false;
					respoonse.Message = "Student not found";
					return respoonse;
				}

				_mapper.Map(updateStudentDto, Student);
				await _dbContext.SaveChangesAsync();

				respoonse.Data = _mapper.Map<StudentDto>(Student);
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

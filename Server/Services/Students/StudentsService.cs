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
				var student = _mapper.Map<Student>(studentsDto);
				student.Role = ApplicationRoles.Student;

				await _dbContext.Students.AddAsync(student);
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

		public async Task<ServiceResponse<bool>> AddStudentToSchoolClass(Guid studentId, Guid schoolClassId)
		{
			try
			{
				var student = await _dbContext.Students
					.FirstOrDefaultAsync(s => s.Id == studentId);
				if (student == null)
					return new ServiceResponse<bool> { Success = false, Message = "student not found" };
				var schoolClass = await _dbContext.SchoolClasses
					.FirstOrDefaultAsync(sc => sc.Id == schoolClassId);
				if (schoolClass == null)
					return new ServiceResponse<bool> { Success = false, Message = "schoolClass not found" };

				student.SchoolClass = schoolClass;
				await _dbContext.SaveChangesAsync();

				return new ServiceResponse<bool> { Data = true };

			}
			catch (Exception ex)
			{
				return new ServiceResponse<bool>() { Success = false, Message = ex.Message };
			}
		}

		public async Task<ServiceResponse<List<GetStudentDto>>> GetStudents()
		{
			var response = new ServiceResponse<List<GetStudentDto>>();
			try
			{
				var students = await _dbContext.Students
					.Include(s => s.SchoolClass)
					.ToListAsync();
				response.Data = students.Select(s=>_mapper.Map<GetStudentDto>(s)).ToList();
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

		public async Task<ServiceResponse<GetStudentDto>> UpdateStudent(UpdateStudentDto updateStudentDto)
		{
			var respoonse = new ServiceResponse<GetStudentDto>();
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

				respoonse.Data = _mapper.Map<GetStudentDto>(Student);
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

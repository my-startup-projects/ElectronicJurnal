using ElectronicJournal.Shared.DTOs.StudentDto;
using ElectronicJournal.Shared.Response;
using ElectronicJournal.Shared.Entity;

namespace ElectronicJournal.Server.Services.Students
{
	public interface IStudentsService
	{
		Task<ServiceResponse<bool>> AddStudent(CreateStudentDto StudentDto);
		Task<ServiceResponse<bool>> RemoveStudent(Guid StudentId);
		Task<ServiceResponse<List<Student>>> GetStudents();
		Task<ServiceResponse<StudentDto>> UpdateStudent(UpdateStudentDto updateStudentDto);
	}
}

using ElectronicJournal.Shared.DTOs.StudentDto;
using ElectronicJournal.Shared.Response;

namespace ElectronicJournal.Server.Services.Students
{
	public interface IStudentsService
	{
		Task<ServiceResponse<bool>> AddStudent(CreateStudentDto StudentDto);
		Task<ServiceResponse<bool>> RemoveStudent(Guid StudentId);
		Task<ServiceResponse<List<GetStudentDto>>> GetStudents();
		Task<ServiceResponse<GetStudentDto>> UpdateStudent(UpdateStudentDto updateStudentDto);
		Task<ServiceResponse<bool>> AddStudentToSchoolClass(Guid studentId, Guid schoolClassId);
	}
}

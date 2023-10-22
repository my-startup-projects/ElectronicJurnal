using ElectronicJournal.Shared.DTOs.SubjectDto;
using ElectronicJournal.Shared.Response;

namespace ElectronicJournal.Server.Services.Subjects
{
	public interface ISubjectsService
	{
		Task<ServiceResponse<Guid>> CreateSubject(CreateSubjectDto subjectDto);
		Task<ServiceResponse<GetSubjectDto>> UpdateSubject(UpdateSubjectDto subjectDto);
		Task<ServiceResponse<List<GetSubjectDto>>> GetSubjects();
		Task<ServiceResponse<bool>> DeleteSubject(Guid id);
	}
}

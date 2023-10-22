
namespace ElectronicJournal.Shared.DTOs.SchoolClassDto
{
	using ElectronicJournal.Shared.DTOs.StudentDto;
	using ElectronicJournal.Shared.DTOs.ScheduleDto;
	public class GetSchoolClassDto
	{
		public Guid Id { get; set; }
		public int Course { get; set; }
		public string Name { get; set; }

		public List<GetStudentDto> Students { get; set; }
		public List<GetScheduleDto> Schedules { get; set; }
	}
}

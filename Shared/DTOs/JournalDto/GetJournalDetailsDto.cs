using ElectronicJournal.Shared.DTOs.ScheduleDto;

namespace ElectronicJournal.Shared.DTOs.JournalDto
{
	public class GetJournalDetailsDto
	{
		public Guid Id { get; set; }
		public string SchoolClassName { get; set; }
		public Guid SchoolClassId { get; set; }
		public List<GetScheduleDto> Schedules { get; set; }
	}

	public class GetScheduleDto
	{
		public Guid Id { get; set; }
		public Guid SubjectID { get; set; }
		public string Subject { get; set; }
		public Guid TeacherID { get; set; }
		public string Teacher { get; set; }
		public DayOfWeek DayOfWeek { get; set; }
		public int Time { get; set; }
	}
}

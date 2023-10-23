namespace ElectronicJournal.Shared.DTOs.ScheduleDto
{
	public class GetScheduleDto
	{
		public Guid Id { get; set; }
		public Guid JournalID { get; set; }
		public string Journal { get; set; }
		public Guid SubjectID { get; set; }
		public string Subject { get; set; }
		public Guid TeacherID { get; set; }
		public string Teacher { get; set; }
		public DayOfWeek DayOfWeek { get; set; }
		public int Time { get; set; }
	}
}

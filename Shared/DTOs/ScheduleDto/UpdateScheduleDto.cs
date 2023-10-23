namespace ElectronicJournal.Shared.DTOs.ScheduleDto
{
	public class UpdateScheduleDto
	{
		public Guid Id { get; set; }
		public Guid JournalID { get; set; }
		public Guid SubjectID { get; set; }
		public Guid TeacherID { get; set; }
		public DayOfWeek DayOfWeek { get; set; }
		public int Time { get; set; }
	}
}

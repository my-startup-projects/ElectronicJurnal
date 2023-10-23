namespace ElectronicJournal.Shared.Entity
{
	public class Schedule : BaseEntity
	{
		public Guid JournalID { get; set; }
		public virtual Journal Journal { get; set; }
		public Guid SubjectID { get; set; }
		public virtual Subject Subject { get; set; }
		public Guid TeacherID { get; set; }
		public virtual Teacher Teacher { get; set; }
		public DayOfWeek DayOfWeek { get; set; }
		public int Time { get; set; }

		public virtual List<Grade> Grades { get; set; }
	}
}

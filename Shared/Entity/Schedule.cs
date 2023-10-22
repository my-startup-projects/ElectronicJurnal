namespace ElectronicJournal.Shared.Entity
{
	public class Schedule : BaseEntity
	{
		public Guid SchoolClassID { get; set; }
		public virtual SchoolClass SchoolClass { get; set; }
		public Guid SubjectID { get; set; }
		public virtual Subject Subject { get; set; } 
		public Guid TeacherID { get; set; }
		public virtual Teacher Teacher { get; set; }
		public DayOfWeek DayOfWeek { get; set; }
		public int Time { get; set; }
	}
}

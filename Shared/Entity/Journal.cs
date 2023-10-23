namespace ElectronicJournal.Shared.Entity
{
	public class Journal : BaseEntity
	{
		public Guid SchoolClassID { get; set; }
		public virtual SchoolClass SchoolClass { get; set; }
		public string AcademicYear { get; set; }

		public virtual List<Schedule> Schedules { get; set; }
	}
}

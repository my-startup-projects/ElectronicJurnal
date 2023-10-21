namespace ElectronicJournal.Shared.Entity
{
	public class SchoolClass : BaseEntity
	{

		public string Name { get; set; }
		public int Course { get; set; }
		public List<Student> Students { get; set; }
		public List<Schedule> Schedules { get; set; }
	}
}

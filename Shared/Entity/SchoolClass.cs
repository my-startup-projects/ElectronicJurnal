namespace ElectronicJournal.Shared.Entity
{
	public class SchoolClass : BaseEntity
	{
		public string Name { get; set; }
		public int Course { get; set; }
		public virtual List<Student> Students { get; set; }
		public virtual List<Journal> Journals { get; set; }
	}
}

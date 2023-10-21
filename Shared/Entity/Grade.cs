namespace ElectronicJournal.Shared.Entity
{
	public class Grade : BaseEntity
	{

		public Guid StudentID { get; set; }
		public Student Student { get; set; }
		public Guid JournalID { get; set; }
		public Journal Journal { get; set; }
		public int GradeValue { get; set; }
		public bool isAbsent { get; set; } = false;
		public DateTime Date { get; set; }
	}
}

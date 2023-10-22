namespace ElectronicJournal.Shared.Entity
{
	public class Exam : BaseEntity
	{

		public Guid StudentID { get; set; }
		public virtual Student Student { get; set; }
		public Guid SubjectID { get; set; }
		public virtual Subject Subject { get; set; }
		public DateTime Date { get; set; }
		public int GradeValue { get; set; }
	}
}

namespace ElectronicJurnal.Shared.Entity
{
	public class Exam : BaseEntity
	{

		public Guid StudentID { get; set; }
		public Student Student { get; set; }
		public Guid SubjectID { get; set; }
		public Subject Subject { get; set; }
		public DateTime Date { get; set; }
		public int GradeValue { get; set; }
	}
}

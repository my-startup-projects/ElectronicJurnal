namespace ElectronicJournal.Shared.Entity
{
	public class Grade : BaseEntity
	{

		
		public Guid JournalID { get; set; }
		public virtual Journal Journal { get; set; }	
		public DateTime Date { get; set; }

		public List<GradeDetail> GradeDetails { get; set; }
	}

	public class GradeDetail : BaseEntity
	{
		public Guid StudentID { get; set; }
		public virtual Student Student { get; set; }
		public int GradeValue { get; set; }
		public bool isAbsent { get; set; } = false;
		public Guid GradeId { get; set; }
		public Grade Grade { get; set; }
	}
}

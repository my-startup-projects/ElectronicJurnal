namespace ElectronicJournal.Shared.Entity
{
	public class Grade : BaseEntity
	{
		
		public Guid ScheduleID { get; set; }
		public virtual Schedule	Schedule { get; set; }	
		public DateTime Date { get; set; }

		public List<GradeDetail> GradeDetails { get; set; }
	}
}

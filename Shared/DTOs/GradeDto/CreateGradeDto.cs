using ElectronicJournal.Shared.Entity;

namespace ElectronicJournal.Shared.DTOs.GradeDto
{
	public class CreateGradeDto
	{
		public Guid StudentID { get; set; }
		public Guid JournalID { get; set; }
		public int GradeValue { get; set; }
		public bool isAbsent { get; set; } = false;
		public DateTime Date { get; set; }
	}
}

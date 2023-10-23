using ElectronicJournal.Shared.Entity;

namespace ElectronicJournal.Shared.DTOs.GradeDetailDto
{
	public class AddGradeDetailDto
	{
		public Guid StudentID { get; set; }
		public int GradeValue { get; set; }
		public bool isAbsent { get; set; } = false;
	}
}

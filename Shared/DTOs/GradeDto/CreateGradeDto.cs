using ElectronicJournal.Shared.DTOs.GradeDetailDto;

namespace ElectronicJournal.Shared.DTOs.GradeDto
{
	public class CreateGradeDto
	{
		public Guid JournalID { get; set; }
		public DateTime Date { get; set; }
		List<AddGradeDetailDto> GradeDetails { get; set; }
	}
}

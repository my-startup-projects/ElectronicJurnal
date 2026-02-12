using ElectronicJournal.Shared.DTOs.GradeDetailDto;

namespace ElectronicJournal.Shared.DTOs.GradeDto
{
	public class CreateGradeDto
	{
		public Guid ScheduleID { get; set; }
		public DateTime Date { get; set; }
	}
}

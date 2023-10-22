namespace ElectronicJournal.Shared.DTOs.TeacherDto
{
	public class GetTeacherDto
	{
		public string UserName { get; set; }
		public Guid Id { get; set; }
		public string FullName { get; set; }
		public string PhoneNumber { get; set; }
		public DateOnly DateOfBirth { get; set; }
	}
}


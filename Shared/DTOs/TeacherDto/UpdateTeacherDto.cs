namespace ElectronicJournal.Shared.DTOs.TeacherDto
{
	public class UpdateTeacherDto
	{
		public Guid Id { get; set; }
		public string PhoneNumber { get; set; }

		public DateOnly DateOfBirth { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; } = "123";

	}
}

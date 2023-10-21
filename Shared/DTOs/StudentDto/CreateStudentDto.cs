
namespace ElectronicJournal.Shared.DTOs.StudentDto
{
	public class CreateStudentDto
	{
		public string FullName { get; set; }
		public string PhoneNumber { get; set; }

		public DateOnly DateOfBirth { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; } = "123";	
		public Guid SchoolClassId { get; set; }
	}
}

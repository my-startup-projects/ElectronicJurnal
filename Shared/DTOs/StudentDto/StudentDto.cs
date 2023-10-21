namespace ElectronicJournal.Shared.DTOs.StudentDto
{
	public class StudentDto
	{
		public string UserName { get; set; }
		public Guid Id { get; set; }
		public string FullName { get; set; }
		public string PhoneNumber { get; set; }
		public DateOnly DateOfBirth { get; set; }
		public string SchoolClassFullName { get; set; }
		public Guid SchoolClassId { get; set; }
	}
}


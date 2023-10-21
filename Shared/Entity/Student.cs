using ElectronicJournal.Shared.Identity;

namespace ElectronicJournal.Shared.Entity
{
	public class Student : ApplicationUser
	{
		public Guid SchoolClassID { get; set; }
		public SchoolClass SchoolClass { get; set; }
	}
}

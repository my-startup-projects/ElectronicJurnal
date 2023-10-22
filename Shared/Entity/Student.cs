using ElectronicJournal.Shared.Identity;

namespace ElectronicJournal.Shared.Entity
{
	public class Student : ApplicationUser
	{
		public Guid SchoolClassID { get; set; }
		public virtual SchoolClass SchoolClass { get; set; }
	}
}

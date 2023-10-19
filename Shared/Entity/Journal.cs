namespace ElectronicJurnal.Shared.Entity
{
	public class Journal : BaseEntity
	{

		public Guid SchoolClassID { get; set; }
		public SchoolClass SchoolClass { get; set; }
		public string AcademicYear { get; set; }
	}
}

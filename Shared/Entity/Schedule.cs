﻿namespace ElectronicJurnal.Shared.Entity
{
	public class Schedule : BaseEntity
	{

		public Guid SchoolClassID { get; set; }
		public SchoolClass SchoolClass { get; set; }
		public Guid SubjectID { get; set; }
		public Subject Subject { get; set; }
		public Guid TeacherID { get; set; }
		public Teacher Teacher { get; set; }
		public DayOfWeek DayOfWeek { get; set; }
		public TimeSpan Time { get; set; }
	}
}

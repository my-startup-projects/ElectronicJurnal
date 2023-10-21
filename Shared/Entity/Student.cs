using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ElectronicJournal.Shared.Identity;

namespace ElectronicJournal.Shared.Entity
{
	public class Student : ApplicationUser
	{
		public Guid SchoolClassID { get; set; }
		public SchoolClass SchoolClass { get; set; }
	}
}

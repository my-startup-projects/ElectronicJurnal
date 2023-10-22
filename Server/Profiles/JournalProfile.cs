using ElectronicJournal.Shared.DTOs.JournalDto;
using ElectronicJournal.Shared.Entity;

namespace ElectronicJournal.Server.Profiles
{
	public class JournalProfile : Profile
	{
		public JournalProfile() {
			CreateMap<CreateJournalDto, Journal>();
		}
	}
}

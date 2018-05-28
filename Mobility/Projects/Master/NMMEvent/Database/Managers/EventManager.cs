using System.Collections.Generic;
using Database.Managers.Interface;
using Database.Factory;
using System.Threading.Tasks;
using Database.Accessors.Interface;

namespace Database.Managers
{
	public class EventManager : IEventInterface
	{
		readonly IEventAccessor EventAccessor = new EngineFactory().CreateEventAccessors();

		public async Task<List<DCEvents>> GetEvents()
		{
			return await EventAccessor.GetEvents();
		}

		public async Task<DCEventDetails> GetEventDetails(int eventId)
		{
			return await EventAccessor.GetEventDetailsByEventId(eventId);
		}
	}
}

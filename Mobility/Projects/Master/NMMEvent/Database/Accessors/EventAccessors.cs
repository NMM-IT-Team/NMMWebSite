using System;
using Database.Accessors.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Database.Accessors
{
	public class EventAccessors : IEventAccessor
	{
		readonly IDatabaseEngine databaseEngine = new DatabaseAccessor();

		public async Task<List<DCEvents>> GetEvents()
		{
			return await databaseEngine.GetEventsAsync(); ;
		}

		public async Task<DCEventDetails> GetEventDetailsByEventId(int eventId)
		{
			return await databaseEngine.GetEventDetailsByEventIdAsync(eventId); ;
		}

	}
}

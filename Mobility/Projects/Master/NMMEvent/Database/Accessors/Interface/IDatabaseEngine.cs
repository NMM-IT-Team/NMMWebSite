using System.Threading.Tasks;
using System.Collections.Generic;

namespace Database.Accessors.Interface
{
	public interface IDatabaseEngine
	{
		Task<List<DCEvents>> GetEventsAsync();
		Task<DCEventDetails> GetEventDetailsByEventIdAsync(int EventId);
		Task AddEvent();
	}
}

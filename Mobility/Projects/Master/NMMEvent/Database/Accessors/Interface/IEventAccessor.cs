using System.Threading.Tasks;
using System.Collections.Generic;
namespace Database.Accessors.Interface
{
	public interface IEventAccessor
	{
		Task<List<DCEvents>> GetEvents();
		Task<DCEventDetails> GetEventDetailsByEventId(int eventId);

	}
}

using System.Collections.Generic;
using System.Threading.Tasks;
namespace Database.Managers.Interface
{
	public interface IEventInterface
	{
		Task<List<DCEvents>> GetEvents();
		Task<DCEventDetails> GetEventDetails(int eventId);
	}
}

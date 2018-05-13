using Database.Managers.Interface;
using Database.Managers;

namespace Database.Factory
{
	public class ManagerFactory : ManagerFactoryInitalizers
	{
		public override IEventInterface CreateEventManager()
		{
			return new EventManager();
		}
	}
}

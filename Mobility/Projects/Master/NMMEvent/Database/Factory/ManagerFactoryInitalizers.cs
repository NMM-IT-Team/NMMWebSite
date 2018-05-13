using System;
using Database.Managers.Interface;
namespace Database.Factory
{
	abstract public class ManagerFactoryInitalizers
	{
		public abstract IEventInterface CreateEventManager();
	}
}

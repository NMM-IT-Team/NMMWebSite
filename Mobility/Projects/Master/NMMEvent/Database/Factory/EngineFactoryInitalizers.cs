using Database.Accessors.Interface;
namespace Database.Factory
{
	abstract public class EngineFactoryInitalizers
	{
		public abstract IEventAccessor CreateEventAccessors();
	}
}

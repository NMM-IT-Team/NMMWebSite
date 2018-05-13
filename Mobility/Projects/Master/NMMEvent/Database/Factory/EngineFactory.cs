using System;
using Database.Accessors.Interface;
using Database.Accessors;
namespace Database.Factory
{
	public class EngineFactory : EngineFactoryInitalizers
	{
		public override IEventAccessor CreateEventAccessors()
		{
			return new EventAccessors();
		}
	}
}

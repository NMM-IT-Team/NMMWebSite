using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Database
{
	public class DCEvents
	{
		#region Properties
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Name { get; set; }

		public string EventDateTime { get; set; }

		public DCEventDetails eventDetails { get; set; }

		public string EventIcon { get; set; }

		#endregion

		public override string ToString()
		{
			return string.Format("[Event: Id={0}, Name={1}, EventDateTime={2}]", Id, Name, EventDateTime);
		}

		public static List<DCEvents> GenerateEventSeedScriptObjects()
		{
			return new List<DCEvents>
			{
				new DCEvents{Name= StringResources.Events.GudiPadva,EventDateTime= StringResources.Events.GudiPadva_Date},
				new DCEvents{Name=StringResources.Events.Picnic,EventDateTime= StringResources.Events.Picnic_Date},
				new DCEvents{Name=StringResources.Events.YogaDay,EventDateTime= StringResources.Events.YogaDay_Date},
				new DCEvents{Name=StringResources.Events.Ganapati,EventDateTime= StringResources.Events.Ganapati_Date},
				new DCEvents{Name=StringResources.Events.Diwali,EventDateTime= StringResources.Events.Diwali_Date},
				new DCEvents{Name=StringResources.Events.Workshops,EventDateTime= StringResources.Events.Workshops_Date}

			};
		}
	}
}

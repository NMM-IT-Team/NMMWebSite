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
			var eventDate = DateTime.Now.ToString("MM/dd/yyyy");

			return new List<DCEvents>
			{
				new DCEvents{Name="GudiPadwa",EventDateTime= "04/08/2018",EventIcon=""},
				new DCEvents{Name="Picnic",EventDateTime= "06/16/2018",EventIcon=""},
				new DCEvents{Name="Ganapati",EventDateTime= "09/16/2018",EventIcon=""},
				new DCEvents{Name="Diwali",EventDateTime= "11/17/2018",EventIcon=""},
				new DCEvents{Name="Workshops",EventDateTime= "Date yet to be finalised",EventIcon=""}

			};
		}
	}
}

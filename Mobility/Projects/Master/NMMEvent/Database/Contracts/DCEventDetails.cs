using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace Database
{
	public class DCEventDetails
	{
		#region Event details
		[PrimaryKey]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public int EventId { get; set; }

		public string Description { get; set; }

		public bool IsCommercial { get; set; }

		public decimal Cost { get; set; }

		public string Location { get; set; }

		public string VenuName { get; set; }

		public string RootFolder { get; set; }

		public List<Contracts.EventImage> EventImages { get; set; }

		#endregion

		public override string ToString()
		{
			return string.Format("[Event desc: Id={0}, Description={1}]", Id, Description);
		}

		public static List<DCEventDetails> GenerateEventDetailsSeedScriptObjects()
		{
			var eventLocation = "13010 Arbor St, Omaha, NE 68144";
			var eventVenuName = "Hindu Temple";

			var padwaDesc = "NMM family invites you to celebrate gudi padwa with your family and loved ones. Come join us to celebrate this wonderful festival together at";


			return new List<DCEventDetails>()
			{
				new DCEventDetails(){EventId=1,Description=padwaDesc,IsCommercial=false,Cost=0,Location=eventLocation,VenuName=eventVenuName,
					RootFolder=""},

				new DCEventDetails(){EventId=2,Description="Picnic description here",IsCommercial=false,Cost=0,Location=eventLocation,VenuName=eventVenuName,
					RootFolder=""},

				new DCEventDetails(){EventId=3,Description="Ganapati description here",IsCommercial=false,Cost=0,Location=eventLocation,
					VenuName=eventVenuName,RootFolder=""},
				new DCEventDetails(){EventId=4,Description="Diwali description here",IsCommercial=false,Cost=0,Location=eventLocation,
					VenuName=eventVenuName,RootFolder=""},

				new DCEventDetails(){EventId=5,Description="Workshop description here",IsCommercial=false,Cost=0,Location=eventLocation,VenuName=eventVenuName,
					RootFolder=""}
			};
		}
	}
}

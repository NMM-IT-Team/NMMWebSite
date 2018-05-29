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
			return new List<DCEventDetails>
				{
				new DCEventDetails{EventId=1,Description=StringResources.EventDetails.PadwaDescription,
					Location=StringResources.EventDetails.HinduTempleLocation,VenuName=StringResources.EventDetails.HinduTempleVenuName},

				new DCEventDetails{EventId=2,Description=StringResources.EventDetails.PicnicDescription,Location=StringResources.EventDetails.PicnicVenuLocation,
					VenuName=StringResources.EventDetails.PicnicVenuName},

				new DCEventDetails{EventId=3,Description=StringResources.EventDetails.YogaDescription,Location=StringResources.EventDetails.HinduTempleLocation,
					VenuName=StringResources.EventDetails.HinduTempleVenuName},

				new DCEventDetails{EventId=4,Description=StringResources.EventDetails.GanapatiDescription,Location=StringResources.EventDetails.HinduTempleLocation,
					VenuName=StringResources.EventDetails.HinduTempleVenuName},

				new DCEventDetails{EventId=5,Description=StringResources.EventDetails.DiwaliDescription,Location=StringResources.EventDetails.HinduTempleLocation,
					VenuName=StringResources.EventDetails.HinduTempleVenuName},

				new DCEventDetails{EventId=6,Description=StringResources.EventDetails.WorkshopDescription,
					Location=StringResources.EventDetails.HinduTempleLocation,VenuName=StringResources.EventDetails.HinduTempleVenuName}
				};
		}
	}
}

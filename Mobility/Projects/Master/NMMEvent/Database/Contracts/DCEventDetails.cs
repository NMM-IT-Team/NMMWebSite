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
			return new List<DCEventDetails>()
			{
				new DCEventDetails(){EventId=1,Description="Padva description here",IsCommercial=false,Cost=0,Location="Temporary location",VenuName="Test Venu name",
					RootFolder=""},

				new DCEventDetails(){EventId=2,Description="Picnic description here",IsCommercial=false,Cost=0,Location="Temporary location",VenuName="Test Venu name",
					RootFolder=""},

				new DCEventDetails(){EventId=3,Description="Ganapati description here",IsCommercial=false,Cost=0,Location="Temporary location",VenuName="Test Venu name",RootFolder=""},
				new DCEventDetails(){EventId=4,Description="Diwali description here",IsCommercial=false,Cost=0,Location="Temporary location",VenuName="Test Venu name",RootFolder=""},
			};
		}
	}
}

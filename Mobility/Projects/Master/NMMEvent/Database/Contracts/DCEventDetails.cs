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
			//TODO: move these strings in a resource file
			var eventLocation = "13010 Arbor St, Omaha, NE 68144";
			var eventVenuName = "Hindu Temple";

			var padwaDesc = "Gudi Padwa is the festival that is celebrated on the first day of the Chaitra month to mark the beginning of the Hindu new year. It is mainly celebrated in Maharashtra. The day is also celebrated as Ugadi, which is also known as Yugadi, is mainly a new year festival in Andhra Pradesh and Karnataka.";
			var ganapatidesc = "Ganesh Chaturthi also known as Vinayaka Chaturthi (Vināyaka Chaturthī) is the Hindu festival that reveres god Ganesha. A ten-day festival, it starts on the fourth day of Hindu luni-solar calendar month Bhadrapada. NMM, Marathi community sponcers/volunteer and excute this event for Hindu Temple of Omaha with Dhole Tasha! and lezim,  music  in Rath yatra and cook pure Maharashtra menu for mahaprasad.\n Ganapati Bappa Moraya!!!";
			var diwaliDesc = "Diwali is festival of lights, prosperity and celebrated for five days. Five days are Dhanteras, Narakchaturdesi, Lakshmi Puja,  Govardhan Puja and BhauBeej. NMM Diwali  is family celebration with food, decoration,  puja, entertainment is performed by community members/local-talent.  We have Diwali celebration photos on NMM website.";
			var yogaDesc = "June 21st is जागतिक योग दिन (International Yoga Day). As a community we will use this opportunity to bring awareness and encourage each other to start our morning with सूर्य नमस्कार (Sun Salutation). This is a step by our community in 'Sarve Bhavantu Sukhinah (सर्वे भवन्तु सुखिनः सर्वे सन्तु निरामयाः)' to promote community health";


			return new List<DCEventDetails>
				{
					new DCEventDetails{EventId=1,Description=padwaDesc,IsCommercial=false,Cost=0,Location=eventLocation,VenuName=eventVenuName,
						RootFolder=""},

					new DCEventDetails{EventId=2,Description="Fun in the sun with family, friends and loved ones. Full of fun outdoor activities, music,  games etc.",IsCommercial=false,Cost=0,Location=eventLocation,VenuName=eventVenuName,
						RootFolder=""},

				new DCEventDetails{EventId=3,Description=yogaDesc,IsCommercial=false,Cost=0,Location=eventLocation,
						VenuName=eventVenuName,RootFolder=""},

					new DCEventDetails{EventId=4,Description=ganapatidesc,IsCommercial=false,Cost=0,Location=eventLocation,
						VenuName=eventVenuName,RootFolder=""},

					new DCEventDetails{EventId=5,Description=diwaliDesc,IsCommercial=false,Cost=0,Location=eventLocation,
						VenuName=eventVenuName,RootFolder=""},

					new DCEventDetails{EventId=6,Description="NMM organises various workshops for all ages. These are member presented for members in various fields including Paintings, Arts. Science, Health and more.",IsCommercial=false,Cost=0,Location=eventLocation,VenuName=eventVenuName,
						RootFolder=""}
				};
		}
	}
}

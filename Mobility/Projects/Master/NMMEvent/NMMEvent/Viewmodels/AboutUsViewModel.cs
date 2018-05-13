using System.Reflection;
using System.IO;
namespace NMMEvent.Viewmodels
{
	public class AboutUsViewModel
	{
		string _aboutUs;
		public string AboutUs
		{
			get { return _aboutUs; }
			set
			{
				_aboutUs = value;
			}
		}

		public AboutUsViewModel()
		{
			var para1 = "(NMM) started with an objective to celebrate and practice marathi culture with Nebraska's Indian community. Few families came with a thought of bringing people together, and with their planning, NMM was officially formed on Sept 6th 2014.";
			var para2 = "NMM was registered with State of Nebraska as a non profit organization in Jan 2015. NMM is also affiliated with BMM (Bruhan Maharashtra Mandal) of North America. Year 2015 started with celebrating various events and also Ganesh festival in Hindu Temple.";
			var para3 = "Year 2016 started with new participative leadership, and board focused on the Community, Culture and Nature (Environment). 'GO GREEN': The care for environment, is the most top achievement that received endorsement from all. Nebraska Marathi Mandal with community help raised fund and took full responsibility for Ganesh Utsav celebration at Hindu temple of Omaha with use of Bio-degradable. We are the first community that practiced Go Green on a large scale. Diwali Dhamaka was the most active, cultural and exciting program for NMM in 2016. NMM received First prize in Rhythms of India 2016 for presenting and displaying various aspects of Marathi Culture. NMM also participated in 'Siddhi Vinayak Vyas-Puraskar' held in 2016.";
			var para4 = "Year 2017 started with the vibrant celebration of 'Gudi Padwa' showcasing Maharashtra-chi Lokadhara (महाराष्ट्राची लोकधारा) and cultural display for the auspicious welcome of Marathi New Year. The NMM board's focus is on amendment into NMM bylaws, board members election process and pilot programs along with all yearly events and workshops. BMM 2017 Convention Participation is another accomplishment.Support of community people, encouraged to establish the organization 'तुमचं आमचं सर्वांचं नेब्रास्का मराठी मंडळ'. NMM is proud of its members, volunteers and people for their inspiration to enable to serve community and culture, alongwith the 'GO GREEN' initiative to protect nature.";

			AboutUs = string.Format("{0}\n\n{1}\n\n{2}\n\n{3}", para1, para2, para3, para4);


		}
	}
}

using System.Collections.Generic;
namespace NMMEvent.Viewmodels
{
	public class Membership
	{
		public string Benefit { get; set; }
		public string Description { get; set; }
	}


	public class MembershipBenefitsViewModel
	{
		List<Membership> _memebershipBenefits;
		public List<Membership> MemebershipBenefits
		{
			get { return _memebershipBenefits; }
			set { _memebershipBenefits = value; }
		}


		public MembershipBenefitsViewModel()
		{
			//TODO: to be moved to the database this is temporary
			MemebershipBenefits = new List<Membership>()
			{
				new Membership(){Benefit="Go Green",Description="Initiative by NMM that cares about mother earth."},
				new Membership(){Benefit="Discounts",Description="Discount in NMM event Fees."},

				new Membership(){Benefit="Talent Development",Description="Local Talent- Create participation, platform for families and friends."},
				new Membership(){Benefit="Partnership",Description="Partnership with Kids in volunteer, acting, dance, etc."},

				new Membership(){Benefit="Rights",Description="Voting Rights through election process and good governance."},

				new Membership(){Benefit="Library",Description="NMM Library – access to rare to find Marathi books."},
				new Membership(){Benefit="Rhythms-IAN",Description="Rhythms-IAN participation"}

			};
		}
	}
}

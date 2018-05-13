using NMMEvent.Viewmodels;
using Xamarin.Forms;

namespace NMMEvent.Interface
{
	public partial class MembershipBenefitsPage : ContentPage
	{
		MembershipBenefitsViewModel _viewModel;

		public MembershipBenefitsPage()
		{
			InitializeComponent();
			_viewModel = new MembershipBenefitsViewModel();
			BindingContext = _viewModel;
			Title = "Benefits";
		}

		//TODO: This needs to go in view model than code behind
		void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			if (e.Item == null) return;
			// do something with e.SelectedItem
			((ListView)sender).SelectedItem = null; // de-select the row
		}
	}
}

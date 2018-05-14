using NMMEvent.Viewmodels;
using Database;

using Xamarin.Forms;

namespace NMMEvent.Interface
{
	public partial class EventPage : ContentPage
	{
		EventPageViewModel _viewModel;

		public EventPage()
		{
			_viewModel = new EventPageViewModel(this.Navigation);
			BindingContext = _viewModel;
			Title = "Events";
			InitializeComponent();

		}

		//TODO: This needs to go in view model than code behind
		void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null)
			{
				var selectedItem = e.SelectedItem as DCEvents;
				_viewModel.DidSelectRow(selectedItem.Id, selectedItem.Name);
			}
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

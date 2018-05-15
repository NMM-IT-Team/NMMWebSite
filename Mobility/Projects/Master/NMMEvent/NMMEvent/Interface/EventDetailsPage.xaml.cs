using Xamarin.Forms;

namespace NMMEvent.Interface
{
	public partial class EventDetailsPage : ContentPage
	{
		public string EventName { get; set; }
		Viewmodels.EventDetailsViewModel _viewModel;

		public EventDetailsPage(int eventId, string eventName)
		{
			_viewModel = new Viewmodels.EventDetailsViewModel(this.Navigation, eventId, eventName);
			BindingContext = _viewModel;
			InitializeComponent();
			Title = eventName;
		}
	}
}

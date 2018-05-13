using Xamarin.Forms;

namespace NMMEvent.Interface
{
	public partial class EventDetailsPage : ContentPage
	{
		public string EventName { get; set; }
		Viewmodels.EventDetailsViewModel _viewModel;

		public EventDetailsPage(int eventId)
		{
			_viewModel = new Viewmodels.EventDetailsViewModel(this.Navigation, eventId);
			BindingContext = _viewModel;
			InitializeComponent();

			//DataTemplate template = new DataTemplate(() =>
			//{
			//	Image image = new Image();
			//	image.SetBinding(Image.SourceProperty, "Picture");

			//	return image;
			//});

			//CarouselView carouselview = new CarouselView()
			//{
			//	ItemsSource = _viewModel.pictures,
			//	ItemTemplate = template
			//};

		}
	}
}

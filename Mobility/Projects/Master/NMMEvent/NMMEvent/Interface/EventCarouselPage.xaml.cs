using System;
using System.Collections.Generic;
using Database.Contracts;

using Xamarin.Forms;

namespace NMMEvent.Interface
{
	public partial class EventCarouselPage : CarouselPage
	{
		public EventCarouselPage(List<EventImage> eventImages)
		{
			InitializeComponent();
			ItemsSource = eventImages;
		}
	}
}
